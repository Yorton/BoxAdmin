using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Application.DTOs.Settings;
using System.Threading;

namespace BoxAdmin.Application.Features.Coupons.Queries.GetCouponById
{
    //public class GetCouponByIdQuery : IRequest<Result<GetCouponByIdResponse>>
    public class GetCouponByIdQuery : IRequest<GetCouponByIdResponse>
    {
        public string Id { get; set; }
    }


    //public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQuery, Result<GetCouponByIdResponse>> 
    public class GetCouponByIdQueryHandler : IRequestHandler<GetCouponByIdQuery, GetCouponByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetCouponByIdQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<GetCouponByIdResponse>> Handle(GetCouponByIdQuery command, CancellationToken cancellationToken)
        public async Task<GetCouponByIdResponse> Handle(GetCouponByIdQuery command, CancellationToken cancellationToken)
        {
            DateTime NowTime = DateTime.Now;

            var queryable = await (from c in _context.Coupons
                                  join cr in _context.CouponRules on c.CouponRuleId equals cr.Id
                                  join ma in _context.MarketingActivities on c.MarketingActivitiesId equals ma.Id into maGroup
                                  from mal in maGroup.DefaultIfEmpty()
                                  where c.Id == command.Id && cr.Enable == true
                                  select new { c, cr, mal }
                                  ).ToListAsync(cancellationToken);

            GetCouponByIdResponse coupon = null;

            if (queryable != null) 
            {
                coupon = queryable.Select(x => new GetCouponByIdResponse
                {
                        Id = x.c.Id,
                        CouponRuleId = x.c.CouponRuleId,
                        MarketingActivitiesId = x.c.MarketingActivitiesId,

                        //Status = (x.mal.CanUseStartDate.HasValue && x.mal.CanUseStartDate > NowTime) && (x.mal.CanUseEndDate.HasValue && x.mal.CanUseEndDate > NowTime) ? "尚未開始"
                        //       : (x.mal.CanUseStartDate.HasValue && x.mal.CanUseStartDate <= NowTime) && (x.mal.CanUseEndDate.HasValue && x.mal.CanUseEndDate >= NowTime) ? "進行中"
                        //       : (x.mal.CanUseStartDate.HasValue && x.mal.CanUseStartDate < NowTime) && (x.mal.CanUseEndDate.HasValue && x.mal.CanUseEndDate < NowTime) ? "已結束" : "",
                        Status = (x.c.StartDate.HasValue && x.c.StartDate > NowTime) && (x.c.EndDate.HasValue && x.c.EndDate > NowTime) ? "尚未開始"
                                   : (x.c.StartDate.HasValue && x.c.StartDate <= NowTime) && (x.c.EndDate.HasValue && x.c.EndDate >= NowTime) ? "進行中"
                                   : (x.c.StartDate.HasValue && x.c.StartDate < NowTime) && (x.c.EndDate.HasValue && x.c.EndDate < NowTime) ? "已結束" : "",

                        CouponName = x.c.Name,

                        CouponType = x.mal.Type,
                        CouponTypeName = x.mal.Type == 1 ? "一般Coupon"
                                                         : x.mal.Type == 2 ? "專屬生日禮"
                                                                           : x.mal.Type == 3 ? "升等會員購物禮"
                                                                                             : x.mal.Type == 4 ? "續訂禮"
                                                                                                               : x.mal.Type == 5 ? "訂閱費折抵"
                                                                                                                                 : x.mal.Type == 6 ? "滿件折"
                                                                                                                                                   : "",
                        ReceiveType = x.mal.ReceiveType,
                        ReceiveTypeName = x.mal.ReceiveType == 1 ? "使用者手動領取/歸戶"
                                                                 : x.mal.ReceiveType == 2 ? "使用者結帳後歸戶"
                                                                                          : x.mal.ReceiveType == 3 ? "系統自動歸戶" : "",
                        SpecialCode = x.c.SpecialCode,

                        MarketingActivityStartDate = x.mal.StartDate.ToString("yyyy/MM/dd"),
                        MarketingActivityEndDate = x.mal.EndDate.ToString("yyyy/MM/dd"),

                        SendTimePoint = x.mal.Type == 1 ? 0
                                                        : x.mal.Type == 2 ? 2
                                                                          : x.mal.Type == 3 ? 3
                                                                                            : x.mal.Type == 4 ? 3
                                                                                                              : x.mal.Type == 5 ? 1
                                                                                                                                : x.mal.Type == 6 ? 1 : 0,
                        SendTimePointName = x.mal.Type == 1 ? "無"
                                                            : x.mal.Type == 2 ? "每個月1號"
                                                                              : x.mal.Type == 3 ? "訂單成立後1天"
                                                                                                : x.mal.Type == 4 ? "訂單成立後1天"
                                                                                                                  : x.mal.Type == 5 ? "系統自動取用"
                                                                                                                                    : x.mal.Type == 6 ? "系統自動取用" : "",

                        SendCondition = x.mal.SendCondition,
                        SendConditionName = x.mal.SendCondition == 1 ? "服務方案續訂訂單成立"
                                                                     : x.mal.SendCondition == 2 ? "商品訂單(盒內商品)結帳時"
                                                                                                : x.mal.SendCondition == 3 ? "生日月為發送日當月" : "",

                        SendLimitType = x.mal.SendLimitType,
                        SendLimitTypeName = x.mal.SendLimitType == 1 ? "活動區間內限領用１張"
                                                                     : x.mal.SendLimitType == 2 ? "活動區間內每天限領用１張" : "",

                        CanUseType = x.mal.CanUseType,
                        CanUseTypeName = x.mal.CanUseType == 0 ? "系統自動取用"
                                                               : x.mal.CanUseType == 1 ? "時間區間"
                                                                                       : x.mal.CanUseType == 2 ? "歸戶後[N]天內可使用" : "",

                        //CanUseStartDate = x.mal.CanUseStartDate?.ToString("yyyy/MM/dd"),
                        //CanUseEndDate = x.mal.CanUseEndDate?.ToString("yyyy/MM/dd"),
                        CanUseStartDate = x.c.StartDate?.ToString("yyyy/MM/dd"),
                        CanUseEndDate = x.c.EndDate?.ToString("yyyy/MM/dd"),

                        CanUseByReceiveDay = x.mal.CanUseByReceiveDay,

                        UseLimitType = x.cr.UseLimitType,
                        UseLimitTypeName = x.cr.UseLimitType == 1 ? "第一張服務訂單成立"
                                                                  : x.cr.UseLimitType == 2 ? "盒內商品數全滿(含加衣券)" : "",

                        OutputType = x.mal.OutputType,
                        OutputTypeName = x.mal.OutputType == 1 ? "即時產出"
                                                               : x.mal.OutputType == 2 ? "預先產出" : "",

                        LimitQuantity = x.mal.LimitQuantity,

                        SendTarget = x.mal.SendTarget,
                        SendTargetName = x.mal.SendTarget == 1 ? "全部會員"
                                                               : x.mal.SendTarget == 2 ? "一般會員"
                                                                                       : x.mal.SendTarget == 3 ? "訂閱會員(季)"
                                                                                                               : x.mal.SendTarget == 4 ? "指定會員" : "",
                        CartType = x.cr.CartType,
                       

                        DiscountThresholdType = x.cr.DiscountThresholdType,
                        DiscountThresholdTypeName = x.cr.DiscountThresholdType == 1 ? "滿" + x.cr.DiscountThresholdValue.ToString() + "件"
                                                                                    : x.cr.DiscountThresholdType == 2 ? "滿"+ x.cr.DiscountThresholdValue.ToString() + "元" : "",
                        DiscountThresholdValue = x.cr.DiscountThresholdValue,

                        DiscountTarget = x.cr.DiscountTarget,
                        DiscountTargetName = x.cr.DiscountTarget == 1 ? "商品總金額" : "",

                        DiscountContentType = x.cr.DiscountContentType,
                        DiscountContentTypeName = x.cr.DiscountContentType == 1 ? " 折"+ x.cr.DiscountContentValue + "元"
                                                                                : x.cr.DiscountContentType == 2 ? "打"+ x.cr.DiscountContentValue + "折" : "",
                        DiscountContentValue = x.cr.DiscountContentValue

                }).FirstOrDefault();

            }

            //return Result<GetCouponByIdResponse>.Success(coupon);
            return await Task.FromResult(coupon);
        }

    }
}
