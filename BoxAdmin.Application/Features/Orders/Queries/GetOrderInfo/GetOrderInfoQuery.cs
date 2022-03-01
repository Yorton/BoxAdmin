using AutoMapper;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Framework.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Orders.Queries.GetOrderInfo
{
    public enum InvDevice
    {
        會員載具 = 1,
        手機條碼 = 2,
        自然人憑證 = 3,
    }

    public class GetOrderInfoQuery : IRequest<GetOrderInfoResponse>
    {
        /// <summary>
        /// 購物訂單編號
        /// </summary>
        [SwaggerParameter(Description = "購物訂單編號")]
        public string TransactionNo { get; set; }
    }

    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderInfoQuery, GetOrderInfoResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetOrderDetailQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetOrderInfoResponse> Handle(GetOrderInfoQuery command, CancellationToken cancellationToken)
        {
            GetOrderInfoResponse response = await (
                from o in _context.Orders
                join r in _context.Reservations on o.SourceTransactionNo equals r.Id into g1
                from r in g1.DefaultIfEmpty()
                join c in _context.CustomerInfos on o.CustomerId equals c.CustomerId into g2
                from c in g2.DefaultIfEmpty()
                join p in _context.OrderPayTypes on o.PayType equals p.Id into g3
                from p in g3.DefaultIfEmpty()
                join s in _context.Shipments on o.TransactionId equals s.TransactionId into g4
                from s in g4.DefaultIfEmpty()
                join rt in _context.Returns on o.TransactionId equals rt.TransactionId into g5
                from rt in g5.DefaultIfEmpty()
                join op in _context.OrderPayments on o.TransactionId equals op.TransactionId into g6
                from op in g6.DefaultIfEmpty()
                where o.TransactionNo == string.Format("{0,-16}", command.TransactionNo)
                select new GetOrderInfoResponse
                {
                    OrderInfo = new OrderInfo() 
                    {
                        TransactionId = o.TransactionId,
                        TransactionNo = o.TransactionNo,
                        BoxNo = r.BoxNo,
                        CustomerId = o.CustomerId,
                        CustomerName = c.Name,
                        Mobile = c.Mobile,
                        PayType = o.PayType,
                        PayTypeName = p.Name,
                        InvDevice = o.InvDevice,
                        InvDeviceCode = o.InvDeviceCode,
                        InvDeviceName = ((InvDevice)int.Parse(o.InvDevice)).ToString(),
                        OrdererName = o.OrdererName,
                        OrdererMobile = o.Mobile,
                        Zip = o.Zip,
                        City = o.City,
                        Region = o.Region,
                        Address = o.Address,
                        CreateTime = o.CreateTime,
                        PreviewDueDate = r.PreviewDueDate,
                        ShipDate = s.ShipDate,
                        // DevileryTime =
                        OrderTime = o.OrderTime,
                        // AppreciationTime =
                        ReturnApplyTime = rt.CreatedAt,
                        RtnDate = rt.RtnDate,
                        RtnNo = rt.RtnNo,
                        IsReturn = !(rt == null),
                        TotalPrice = o.TotalPrice,
                    },
                    Payment = op,
                    Shipment = s,
                }).FirstOrDefaultAsync(cancellationToken);

            List<OrderDetail> details = await (
                from it in _context.OrderItems
                join st in _context.OrderItemStates on it.State equals st.Id into g1
                from st in g1.DefaultIfEmpty()
                join s in _context.ProductSkus on it.Sku equals s.Sku into g2
                from s in g2.DefaultIfEmpty()
                join im in _context.ProductImages
                on new
                {
                    Series = s.Series,
                    Type = 3,
                    Sort = 1
                }
                equals new
                {
                    Series = im.Series,
                    Type = im.Type,
                    Sort = im.Sort
                } into g3
                from im in g3.DefaultIfEmpty()
                where it.TransactionId == response.OrderInfo.TransactionId
                select new OrderDetail
                {
                    ImagePath = im.ImagePath + im.Filename,
                    Sku = it.Sku,
                    SkuName = it.SkuName,
                    Color = s.Color,
                    Size = s.Size,
                    State = it.State,
                    StateName = st.Title,
                    SellingPrice = it.SellingPrice,
                    Discount = it.Discount,
                    TotalPrice = it.TotalPrice,
                }).ToListAsync(cancellationToken);

            response.Details = details;

            return await Task.FromResult(response);
        }
    }
}
