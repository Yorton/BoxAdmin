using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace BoxAdmin.Application.Features.Reservations.Commands.AddReservationOrder
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class AddReservationOrderCommand : IRequest<AddReservationOrderResponse>
    {
        /// <summary>
        /// BOX預約單ID
        /// </summary>
        public string ReservationId { get; set; }
    }

    public class AddReservationOrderCommandHandler : IRequestHandler<AddReservationOrderCommand, AddReservationOrderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IConfiguration _configuration;

        public AddReservationOrderCommandHandler(IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
            _configuration = configuration;
    }

        public async Task<AddReservationOrderResponse> Handle(AddReservationOrderCommand command, CancellationToken cancellationToken)
        {
            if (command == null || string.IsNullOrEmpty(command.ReservationId))
            {
                throw new Exception("Id is null");
            }

            AddReservationOrderResponse addReservationOrderResponse = new AddReservationOrderResponse();

            var reservationQuery = await _context.Reservations
                 .Include(x => x.ReservationLineItemGroups)
                    .ThenInclude(it => it.ReservationLineItems)
                 .Include(x => x.ReservationLineItems)
                 .SingleOrDefaultAsync(x => x.Id == Guid.Parse(command.ReservationId), cancellationToken) ??
                 throw new ArgumentException($"Reservations not found", $"{nameof(command.ReservationId)}");

            DateTime NowTime = DateTime.Now;

            using (var dbtc = _context.BeginTransaction)
            {
                try
                {
                    string OrdererName = _context.ReservationCustomers.FirstOrDefault(x => x.ReservationId == reservationQuery.Id).Name;
                    ReservationRecipient ReservationRecipient = _context.ReservationRecipients.FirstOrDefault(x => x.ReservationId == reservationQuery.Id);
         
                    #region Order
                    var boxOrderList = (from r in reservationQuery.ReservationLineItems
                                    join p in _context.ProductSkus on r.Sku equals p.Sku into rpGroup
                                    from rp in rpGroup.DefaultIfEmpty()
                                    join ps in _context.ProductSeries on rp.Series equals ps.Series into rppsGroup
                                    from rpps in rppsGroup.DefaultIfEmpty()
                    select new BoxOrder
                    {
                        TransactionId = Guid.NewGuid(),
                        SourceTransactionNo = reservationQuery.Id,
                        TransactionNo = GetTransactionNo(),
                        CustomerId = reservationQuery.CustomerId,
                        OrderType = 2, //Box預約單
                        Currency = "TWD",
                        TotalPrice = rpps.PriceMax, 
                        PaymentAmt = rpps.PriceMax, 
                        OrderTime = NowTime,
                        OrderState = 77, //訂單處理中 
                        PayType = 3, //信用卡 
                        CardNumber = "1234", 
                        TaxIdNumber = reservationQuery.TaxIdNumber,
                        OrdererName = OrdererName,
                        RecipientName = ReservationRecipient.Name,
                        Country = ReservationRecipient.Country,
                        Zip = ReservationRecipient.Zip,
                        City = ReservationRecipient.City,
                        Region = ReservationRecipient.Region,
                        Address = ReservationRecipient.Address,
                        Mobile = ReservationRecipient.Mobile,
                        MobileEncrypt = 0,
                        DeliveryMethod = 2, //黑貓宅急便 
                        Verify = true, //已核帳 
                        VerifyAuditor = "_BOT_", //核帳人 
                        VerifyRemark = "", //核帳備註 
                        PreOrder = 0, //預購 
                        Ip = "127.0.0.1",
                        Platform = "web",
                        Source = "Box",
                        InvDonateYn = false,
                        InvDevice = reservationQuery.InvDevice.ToString(),
                        InvDeviceCode = reservationQuery.InvDeviceCode,
                        InvReceiver = ReservationRecipient.Name,
                        InvReceiverTel = ReservationRecipient.Mobile,
                        InvReceiverAddr = ReservationRecipient.Address,
                        Creator = _authenticatedUserService.UserId,
                        CreateTime = NowTime,
                        Sku = r.Sku,
                        SkuName = rpps.Name
                    }).ToList();

                    if (boxOrderList != null) 
                    {
                        //List<Order> orderList = _mapper.Map<List<Order>>(boxOrderList);//failed

                        foreach (BoxOrder boxOrder in boxOrderList) 
                        {
                            _context.Orders.Add(new Order 
                            {
                                TransactionId = boxOrder.TransactionId,
                                SourceTransactionNo = boxOrder.SourceTransactionNo,
                                TransactionNo = boxOrder.TransactionNo,
                                CustomerId = boxOrder.CustomerId,
                                OrderType = boxOrder.OrderType, 
                                Currency = boxOrder.Currency,
                                TotalPrice = boxOrder.TotalPrice, 
                                PaymentAmt = boxOrder.PaymentAmt, 
                                OrderTime = boxOrder.OrderTime,
                                OrderState = boxOrder.OrderState, 
                                PayType = boxOrder.PayType, 
                                CardNumber = boxOrder.CardNumber, 
                                TaxIdNumber = boxOrder.TaxIdNumber,
                                OrdererName = boxOrder.OrdererName,
                                RecipientName = boxOrder.RecipientName,
                                Country = boxOrder.Country,
                                Zip = boxOrder.Zip,
                                City = boxOrder.City,
                                Region = boxOrder.Region,
                                Address = boxOrder.Address,
                                Mobile = boxOrder.Mobile,
                                MobileEncrypt = boxOrder.MobileEncrypt,
                                DeliveryMethod = boxOrder.DeliveryMethod,
                                Verify = boxOrder.Verify, 
                                VerifyAuditor = boxOrder.VerifyAuditor, 
                                VerifyRemark = boxOrder.VerifyRemark, 
                                PreOrder = boxOrder.PreOrder,
                                Ip = boxOrder.Ip,
                                Platform = boxOrder.Platform,
                                Source = boxOrder.Source,
                                InvDonateYn = boxOrder.InvDonateYn,
                                InvDevice = boxOrder.InvDevice,
                                InvDeviceCode = boxOrder.InvDeviceCode,
                                InvReceiver = boxOrder.InvReceiver,
                                InvReceiverTel = boxOrder.InvReceiverTel,
                                InvReceiverAddr = boxOrder.InvReceiverAddr,
                                Creator = boxOrder.Creator,
                                CreateTime = boxOrder.CreateTime
                            });
                        }
                    }
                    #endregion

                    #region OrderItem

                    List<OrderItem> OrderItemList = null;

                    if (boxOrderList != null)
                    {
                        OrderItemList = new List<OrderItem>();

                        foreach (BoxOrder boxOrder in boxOrderList)
                        {
                            OrderItemList.Add(new OrderItem 
                            {
                                Id = Guid.NewGuid(),
                                TransactionId = boxOrder.TransactionId,
                                CustomerId = boxOrder.CustomerId,
                                Sku = boxOrder.Sku,
                                SkuName = boxOrder.SkuName,
                                OrderDateTime = NowTime,
                                SellingPrice = boxOrder.TotalPrice,  
                                Discount = 0, 
                                Quentity = 1, 
                                TotalPrice = boxOrder.TotalPrice, 
                                Currency = 0,
                                State = 2, //OB下標
                                Verifity = true,
                                OrderType = 1, //一般盒子
                                Store = "官網大碼",
                                PromoId = -1,
                                TrackingId = -1,
                                ProductCost = 0, //商品成本價 
                                ProductCostCurrency = 0,
                                CreatedDate = NowTime
                            });
                        }
                    }

                    if (OrderItemList != null)
                    {
                        foreach (OrderItem orderItem in OrderItemList)
                        {
                            _context.OrderItems.Add(orderItem);
                        }
                    }
                    #endregion

                    #region Shipment

                    List<Shipment> ShipmentList = null;

                    if (boxOrderList != null) 
                    {
                        ShipmentList = new List<Shipment>();

                        foreach (BoxOrder boxOrder in boxOrderList) 
                        {
                            ShipmentList.Add(new Shipment
                            {
                                ShipmentId = Guid.NewGuid(),
                                TransactionId = boxOrder.TransactionId,
                                CustomerId = reservationQuery.CustomerId,
                                TaxIdNumber = reservationQuery.TaxIdNumber,
                                OrdererName = OrdererName,
                                RecipientName = ReservationRecipient.Name,
                                Country = ReservationRecipient.Country,
                                Zip = ReservationRecipient.Zip,
                                City = ReservationRecipient.City,
                                Region = ReservationRecipient.Region,
                                Address = ReservationRecipient.Address,
                                Mobile = ReservationRecipient.Mobile,
                                MobileEncrypt = 0,
                                DeliveryMethod = 2, //黑貓宅急便 
                                Verify = true,
                                VerifyDate = NowTime,
                                VerifyAuditor = "_BOT_",
                                ShipDate = NowTime,
                                RealShipDate = NowTime,
                                ShippingNo = "0",
                                InvDate = NowTime,
                                InvAmt = 0,
                                Invoice = true,
                                Payment = true,
                                State = 0,
                                Weight = 0
                            });
                        }
                    }

                    if (ShipmentList != null)
                    {
                        foreach (Shipment shipment in ShipmentList)
                        {
                            _context.Shipments.Add(shipment);
                        }
                    }
                    #endregion

                    #region ShipmentOrderItem
                    if (ShipmentList != null)
                    {
                        foreach (Shipment shipment in ShipmentList)
                        {
                            _context.ShipmentOrderItems.Add(new ShipmentOrderItem
                            {
                                Id = Guid.NewGuid(),
                                ShipmentId = shipment.ShipmentId,
                                OrderItemId = OrderItemList.FirstOrDefault(x => x.TransactionId == shipment.TransactionId).Id,
                                CreatedAt = NowTime
                            });
                        }
                    }
 
                    #endregion

                    var count = await _context.SaveChangesAsync(cancellationToken);
                    dbtc.Commit();

                    addReservationOrderResponse.Message = "儲存成功";
                }
                catch (Exception e)
                {
                    addReservationOrderResponse.Message = e.Message;
                    dbtc.Rollback();
                    throw;
                }
            }
            return addReservationOrderResponse;
        }


        private string GetTransactionNo()
        {
            string TransactionNo = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("BoxAdminConnection")))
                {

                    String sql = @"SELECT (('P'+format(getdate(),'yyyyMMdd'))+right(replicate('0',(7))+CONVERT([nvarchar],NEXT VALUE FOR [SysNumSeq]),(7)))";

                    using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        TransactionNo = sqlCommand.ExecuteScalar().ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                return "";
            }

            return TransactionNo;
        }


    }
}
