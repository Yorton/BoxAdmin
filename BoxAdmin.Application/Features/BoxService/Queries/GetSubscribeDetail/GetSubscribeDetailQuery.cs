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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeDetail
{
    public class GetSubscribeDetailQuery : IRequest<GetSubscribeDetailResponse>
    {
        /// <summary>
        /// 訂閱服務ID
        /// </summary>
        [SwaggerParameter(Description = "訂閱服務ID")]
        public string Id { get; set; }

        /// <summary>
        /// 訂閱服務編號
        /// </summary>
        [SwaggerParameter(Description = "訂閱服務編號")]
        public string SubscribeNo { get; set; }
    }

    public class GetSubscribeDetailQueryHandler : IRequestHandler<GetSubscribeDetailQuery, GetSubscribeDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetSubscribeDetailQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

      
        public async Task<GetSubscribeDetailResponse> Handle(GetSubscribeDetailQuery command, CancellationToken cancellationToken)
        {
            GetSubscribeDetailResponse response = new GetSubscribeDetailResponse();

            #region 服務訂單主檔

            var queryable = await (from s in _context.Subscribes
                                   join sp in _context.SubscriptionPlanInfos on s.SubscriptionPlanId equals sp.Id
                                   join ss in _context.SubscribeStates on s.State equals ss.Id

                                   join o in _context.Orders.Where(x => x.OrderType == 3) //訂閱服務單
                                   on s.Id equals o.SourceTransactionNo into soGroup
                                   from so in soGroup.DefaultIfEmpty()

                                   join op in _context.OrderPayTypes on so.PayType equals op.Id into soopGroup
                                   from soop in soopGroup.DefaultIfEmpty()

                                   join ci in _context.CustomerInfos on s.CustomerId equals ci.CustomerId into sciGroup
                                   from sci in sciGroup.DefaultIfEmpty()

                                   where s.Id == Guid.Parse(command.Id)
                                   select new
                                   {
                                       SubscribeNo = s.SubscribeNo,
                                       CustomerId = sci.CustomerId,
                                       CustomerName = sci.Name,
                                       SuspendName = "",
                                       CreatedMethodName = s.AutoRenew == false ? "會員下單" : "自動續約",
                                       SourceTransactionNo = (so.SourceTransactionNo != null) ? so.SourceTransactionNo.ToString() : "",
                                       CreatedMethodTime = s.CreatedAt.ToString("yyyy-MM-dd HH:mm"),
                                       PaymentWay = soop.Name != null ? soop.Name : "無",
                                       Invoicing = (so.TaxIdNumber != null && so.InvDevice != null)
                                               ?
                                                so.TaxIdNumber + "("
                                                + (so.InvDevice == "1" ? "會員載具"
                                                                       : so.InvDevice == "2" ? "手機條碼"
                                                                                             : so.InvDevice == "3" ? "自然然憑證"
                                                                                                                   : "")
                                                + ")"
                                               : "無"

                                   }).ToListAsync(cancellationToken);

            response.MainSubscribeData = queryable.Select(x => new MainSubscribe
            {
                SubscribeNo = x.SubscribeNo,
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                SuspendName = x.SuspendName,
                CreatedMethodName = x.CreatedMethodName,
                SourceTransactionNo = x.SourceTransactionNo.ToString(),
                CreatedMethodTime = x.CreatedMethodTime,
                PaymentWay = x.PaymentWay,
                Invoicing = x.Invoicing
            }).FirstOrDefault();

            #endregion

            #region 訂閱資訊
            response.SubscribeInfoData = new SubscribeInfo();
            response.SubscribeInfoData.PlanPrice = 390;
            response.SubscribeInfoData.DiscountQuantity = 0;
            response.SubscribeInfoData.BoxAddedQuantity = 0;
            response.SubscribeInfoData.PaymentAmount = 390;
            #endregion

            #region Box預約單List

            var reservationQueryable = await (from s in _context.Subscribes
                                              join r in _context.Reservations on s.Id equals r.SubscribeId
                                   where s.Id == Guid.Parse(command.Id) 
                                   select new
                                   {
                                       BoxNo = r.BoxNo,
                                       ReservationDueTime = r.State == 1 ? r.ModifiedAt : null,
                                       Status = r.State == -1 ? "未啟用" : "已啟用"
                                   }).ToListAsync(cancellationToken);

            if (reservationQueryable != null)
            {
                response.BoxReservationData = reservationQueryable.Select(x => new BoxReservation
                {
                    BoxNo = x.BoxNo,
                    ReservationDueTime = x.ReservationDueTime != null ? x.ReservationDueTime?.ToString("yyyy-MM-dd HH:mm") : "",
                    Status = x.Status

                }).ToList();
            }

            #endregion

            return await Task.FromResult(response);

        }
    }
}
