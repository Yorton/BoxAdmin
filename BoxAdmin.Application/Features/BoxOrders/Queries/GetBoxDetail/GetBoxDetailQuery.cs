using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Application.DTOs.Settings;
using System.Threading;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxDetail
{
    public class GetBoxDetailQuery : IRequest<GetBoxDetailResponse>
    {
        /// <summary>
        /// BOX預約單ID
        /// </summary>
        [SwaggerParameter(Description = "BOX預約單ID")]
        public string Id { get; set; }

        /// <summary>
        /// BOX訂閱盒編號
        /// </summary>
        //[SwaggerParameter(Description = "BOX訂閱盒編號")]
        //public string BoxNo { get; set; }
    }

    public class GetBoxDetailQueryHandler : IRequestHandler<GetBoxDetailQuery, GetBoxDetailResponse>
    {
        private readonly ProductSettings _productSettings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetBoxDetailQueryHandler(IOptions<ProductSettings> productSettings, IMapper mapper, IBoxDbContext context)
        {
            _productSettings = productSettings.Value;
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<GetBoxDetailResponse>> Handle(GetBoxDetailQuery command, CancellationToken cancellationToken)
        public async Task<GetBoxDetailResponse> Handle(GetBoxDetailQuery command, CancellationToken cancellationToken)
        {
            GetBoxDetailResponse response = new GetBoxDetailResponse();

            #region Box預約單主檔
            var reservationQueryable = await (
                from r in _context.Reservations.Include(x => x.ReservationLineItems)
                join o in _context.Orders.Where(x => x.OrderType == 2) on r.Id equals o.SourceTransactionNo into roGroup
                from ro in roGroup.DefaultIfEmpty()
                join oi in _context.OrderItems on ro.TransactionId equals oi.TransactionId into rooiGroup
                from rooi in rooiGroup.DefaultIfEmpty()
                join ci in _context.CustomerInfos on r.CustomerId equals ci.CustomerId into rciGroup
                from rci in rciGroup.DefaultIfEmpty()
                join mi in _context.MatchmakerInfos on r.MatchmakerId equals mi.Id into rmiGroup
                from rmi in rmiGroup.DefaultIfEmpty()
                where r.Id == Guid.Parse(command.Id) //&& ro.OrderType == 2 //Box預約單
                select new
                {
                    BoxNo = r.BoxNo,
                    TransactionNo = ro.TransactionNo,
                    ReturnNo = rooi.ReturnNo,
                    CustomerId = rci.CustomerId,
                    CustomerName = rci.Name,
                    Mobile = rci.Mobile,
                    MatchmakerName = "",//rmi.Name,
                    DeliveryExpected = r.DeliveryExpected
                }).ToListAsync(cancellationToken);

            if (reservationQueryable != null && reservationQueryable.Count > 0)
            {
                response.MainReservationData = reservationQueryable.Select(x => new MainReservation
                {
                    BoxNo = x.BoxNo,
                    TransactionNo = x.TransactionNo,
                    ReturnNo = x.ReturnNo != null ? x.ReturnNo : "",
                    CustomerId = x.CustomerId,
                    CustomerName = x.CustomerName,
                    Mobile = x.Mobile,
                    MatchmakerName = x.MatchmakerName,
                    DeliveryExpected = x.DeliveryExpected?.ToString("yyyy/MM.dd")
                }).FirstOrDefault();
            }

            #endregion

            #region 歷程檔

            var timeRecordsQueryable = await (
                from r in _context.Reservations.Include(x => x.ReservationLineItems)
                join o in _context.Orders.Where(x => x.OrderType == 2) on r.Id equals o.SourceTransactionNo into roGroup
                from ro in roGroup.DefaultIfEmpty()
                join oi in _context.OrderItems on ro.TransactionId equals oi.TransactionId into rooiGroup
                from rooi in rooiGroup.DefaultIfEmpty()
                join s in _context.Shipments on ro.TransactionId equals s.TransactionId into rosGroup
                from ros in rosGroup.DefaultIfEmpty()
                where r.Id == Guid.Parse(command.Id) //&& ro.OrderType == 2//Box預約單
                select new
                {
                    //BOX啟用(預約完成)時間
                    PreviewDueDate = r.PreviewDueDate,
                    DeliveryExpected = r.DeliveryExpected,
                    //是否表態
                    ShipDate = ros.ShipDate != null ? ros.ShipDate.ToString("yyyy/MM/dd") : "",
                    //TryonExpire //試穿期限 收到盒子後隔天起算試穿日+3
                    OrderDateTime = rooi.OrderDateTime != null ? rooi.OrderDateTime.ToString("yyyy/MM/dd") : "",
                    ReturnTime = rooi.ReturnTime
                    //退回檢驗完成時間
                }).Distinct().ToListAsync(cancellationToken);


            if (timeRecordsQueryable != null && timeRecordsQueryable.Count > 0)
            {
                response.TimeRecordsData = timeRecordsQueryable.Select(x => new TimeRecords
                {
                    //BOX啟用(預約完成)時間

                    PreviewDueDate = x.PreviewDueDate != null ? x.PreviewDueDate?.ToString("yyyy-MM-dd HH:mm") : "",
                    DeliveryExpected = x.DeliveryExpected!= null ? x.DeliveryExpected?.ToString("yyyy-MM-dd HH:mm") : "",

                    //表態完成時間

                    ShipDate = x.ShipDate, //.ToString("yyyy-MM-dd HH:mm"),

                    //配達時間

                    //TryonExpire //試穿期限 收到盒子後(配達日)隔天起算試穿日+3 = 配達日+4
                    TryonExpire = "",

                    OrderDateTime = x.OrderDateTime, //.ToString("yyyy-MM-dd HH:mm"),
                    ReturnTime = x.ReturnTime != null ? x.ReturnTime?.ToString("yyyy-MM-dd HH:mm") : ""

                    //退回檢驗完成時間
                }).FirstOrDefault();

            }
  
            #endregion

            #region 預約商品清單

            var reservationQuery = _context.Reservations
            .Include(x => x.ReservationLineItemGroups)
               .ThenInclude(it => it.ReservationLineItems)
            .Include(x => x.ReservationLineItems)
            .SingleOrDefault(x => x.Id == Guid.Parse(command.Id));

            var productsPreviewQueryable =  (
                from r in reservationQuery.ReservationLineItems
                join ps in _context.ProductSkus on r.Sku equals ps.Sku 
                join p in _context.ProductSeries on ps.Series equals p.Series into rpspGroup
                from rpsp in rpspGroup.DefaultIfEmpty()
                join pi in _context.ProductImages.Where(x => x.Type == 1 && x.Sort == 1) on rpsp.Series equals pi.Series into rppiGroup
                from rppi in rppiGroup.DefaultIfEmpty()
                select new 
                {
                    Id = reservationQuery.Id,
                    Picture = (rppi.ImagePath != null && rppi.Filename != null) ? _productSettings.ImageUrl + rppi.ImagePath + rppi.Filename : "",
                    SKU = r.Sku,
                    ProductName = rpsp.Name,
                    ProductSpec = (ps.Color != null && ps.Size != null) ? ps.Color + (ps.Color.Contains("色") ? "," : "色,") + ps.Size : "",
                    DislikeFeedback = r.DislikeFeedback
                }).Distinct().ToList();

            if (productsPreviewQueryable != null && productsPreviewQueryable.Count > 0)
            {
                response.ProductsPreviewData = new List<ProductsPreview>();

                response.ProductsPreviewData = productsPreviewQueryable.Select(x => new ProductsPreview
                {
                    Picture = x.Picture,
                    SKU = x.SKU,
                    ProductName = x.ProductName,
                    ProductSpec = x.ProductSpec,
                    ProductNoted = x.DislikeFeedback ? "不喜歡" : ""
                }).ToList();
            }

            #endregion

            #region 出貨商品清單

            var shipmentQuery = _context.Reservations
                .Include(x => x.ReservationLineItemGroups)
                    .ThenInclude(it => it.ReservationLineItems)
                .Include(x => x.ReservationLineItems)
                .SingleOrDefault(x => x.Id == Guid.Parse(command.Id));

            var productsShipmentQueryable = (
                 from r in reservationQuery.ReservationLineItems
                 join ps in _context.ProductSkus on r.Sku equals ps.Sku 
                 join p in _context.ProductSeries on ps.Series equals p.Series into rpspGroup
                 from rpsp in rpspGroup.DefaultIfEmpty()
                 join pi in _context.ProductImages.Where(x => x.Type == 1 && x.Sort == 1) on rpsp.Series equals pi.Series into rppiGroup
                 from rppi in rppiGroup.DefaultIfEmpty()
                 select new
                 {
                    Id = shipmentQuery.Id,
                    Picture = (rppi.ImagePath != null && rppi.Filename != null) ? _productSettings.ImageUrl + rppi.ImagePath + rppi.Filename : "",
                    SKU = r.Sku,
                    ProductName = rpsp.Name,
                    ProductSpec = (ps.Color != null && ps.Size != null) ? ps.Color + (ps.Color.Contains("色") ? "," : "色,") + ps.Size : "",
                    Price = rpsp.PriceMax,
                    RefundNoted = _context.Orders.Where(x => x.SourceTransactionNo == shipmentQuery.Id)
                                .Join(_context.OrderItems, x => x.TransactionId, y => y.TransactionId, 
                                (x, y) => new { y.ReturnNo}).Any(x => x.ReturnNo != null) ? "退回"
                                : _context.Orders.Where(x => x.SourceTransactionNo == shipmentQuery.Id).Any()
                                ? "已選購" : ""
                 }).Distinct().ToList();

            if (productsShipmentQueryable != null && productsShipmentQueryable.Count > 0)
            {
                response.ProductsShipmentData = new List<ProductsShipment>();

                response.ProductsShipmentData = productsShipmentQueryable.Select(x => new ProductsShipment
                {
                    Picture = x.Picture,
                    SKU = x.SKU,
                    ProductName = x.ProductName,
                    ProductSpec = x.ProductSpec,
                    Price = x.Price > 0 ? x.Price.ToString() : "",
                    RefundNoted = x.RefundNoted

                }).ToList();
            }


            #endregion

            return await Task.FromResult(response);
        }
    }




}
