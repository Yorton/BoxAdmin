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

namespace BoxAdmin.Application.Features.Coupons.Queries.GetCoupons
{
    //public class GetCouponsQuery : IRequest<Result<List<GetCouponsResponse>>>
    public class GetCouponsQuery : IRequest<List<GetCouponsResponse>>
    {
        /// <summary>
        /// Coupon名稱
        /// </summary>
        [SwaggerParameter(Description = "Coupon名稱")]
        public string CouponName { get; set; }

        /// <summary>
        /// Coupon活動時間開始日
        /// </summary>
        [SwaggerParameter(Description = "Coupon活動時間開始日")]
        public string MarketingActivityStartDate { get; set; }

        /// <summary>
        /// Coupon活動時間結束日
        /// </summary>
        [SwaggerParameter(Description = "Coupon活動時間結束日")]
        public string MarketingActivityEndDate { get; set; }

        /// <summary>
        /// 狀態類型- 1:尚未開始, 2:進行中, 3:已結束
        /// </summary>
        [SwaggerParameter(Description = "狀態類型- 1:尚未開始, 2:進行中, 3:已結束")]
        public string StatusType { get; set; }

    }

    //public class GetCouponsQueryHandler : IRequestHandler<GetCouponsQuery, Result<List<GetCouponsResponse>>>
    public class GetCouponsQueryHandler : IRequestHandler<GetCouponsQuery, List<GetCouponsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetCouponsQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<List<GetCouponsResponse>>> Handle(GetCouponsQuery command, CancellationToken cancellationToken)
        public async Task<List<GetCouponsResponse>> Handle(GetCouponsQuery command, CancellationToken cancellationToken)
        {
            DateTime NowTime = DateTime.Now;
            List<GetCouponsResponse> list = null;

            var queryable = await (from c in _context.Coupons
                                    join cr in _context.CouponRules on c.CouponRuleId equals cr.Id
                                    join ma in _context.MarketingActivities on c.MarketingActivitiesId equals ma.Id into maGroup
                                    from mal in maGroup.DefaultIfEmpty()
                                    where cr.Enable == true
                                    orderby mal.StartDate descending
                                    select new { c, cr, mal }
                            ).Take(500).ToListAsync(cancellationToken);



            if (!string.IsNullOrEmpty(command.CouponName))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => !string.IsNullOrEmpty(x.c.Name) ? x.c.Name.Contains(command.CouponName) : false).ToList();
            }

            if (!string.IsNullOrEmpty(command.MarketingActivityStartDate) && string.IsNullOrEmpty(command.MarketingActivityEndDate))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.mal.StartDate >= DateTime.Parse($"{command.MarketingActivityStartDate:yyyy-MM-dd} 00:00:00")
                                                    && x.mal.EndDate <= NowTime).ToList();
                //起：有日期、迄：空白，從指定日期到現在
            }

            if (string.IsNullOrEmpty(command.MarketingActivityStartDate) && !string.IsNullOrEmpty(command.MarketingActivityEndDate))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.mal.EndDate <= DateTime.Parse($"{command.MarketingActivityEndDate:yyyy-MM-dd} 23:59:59")).ToList();
                //起：空白、迄：有日期，從最早到指定日期
            }

            if (!string.IsNullOrEmpty(command.MarketingActivityStartDate) && !string.IsNullOrEmpty(command.MarketingActivityEndDate))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.mal.StartDate >= DateTime.Parse($"{command.MarketingActivityStartDate:yyyy-MM-dd} 00:00:00")
                                                    && x.mal.EndDate <= DateTime.Parse($"{command.MarketingActivityEndDate:yyyy-MM-dd} 23:59:59")).ToList();
            }

            if (!string.IsNullOrEmpty(command.StatusType))
            {
                if (queryable != null)
                {
                    //switch (command.StatusType)
                    //{
                    //    case "1"://尚未開始
                    //        queryable = queryable.Where(x => (x.mal.CanUseStartDate.HasValue && x.mal.CanUseStartDate > DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 00:00:00"))
                    //                                      && (x.mal.CanUseEndDate.HasValue && x.mal.CanUseEndDate > DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 23:59:59"))).ToList();
                    //        break;
                    //    case "2"://進行中
                    //        queryable = queryable.Where(x => (x.mal.CanUseStartDate.HasValue && x.mal.CanUseStartDate <= DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 00:00:00"))
                    //                                      && (x.mal.CanUseEndDate.HasValue && x.mal.CanUseEndDate >= DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 23:59:59"))).ToList();
                    //        break;
                    //    case "3"://已結束
                    //        queryable = queryable.Where(x => (x.mal.CanUseStartDate.HasValue && x.mal.CanUseStartDate < DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 00:00:00"))
                    //                                      && (x.mal.CanUseEndDate.HasValue && x.mal.CanUseEndDate < DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 23:59:59"))).ToList();
                    //        break;
                    //}

                    switch (command.StatusType)
                    {
                        case "1"://尚未開始
                            queryable = queryable.Where(x => (x.c.StartDate.HasValue && x.c.StartDate > DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 00:00:00"))
                                                            && (x.c.EndDate.HasValue && x.c.EndDate > DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 23:59:59"))).ToList();
                            break;
                        case "2"://進行中
                            queryable = queryable.Where(x => (x.c.StartDate.HasValue && x.c.StartDate <= DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 00:00:00"))
                                                            && (x.c.EndDate.HasValue && x.c.EndDate >= DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 23:59:59"))).ToList();
                            break;
                        case "3"://已結束
                            queryable = queryable.Where(x => (x.c.StartDate.HasValue && x.c.StartDate < DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 00:00:00"))
                                                            && (x.c.EndDate.HasValue && x.c.EndDate < DateTime.Parse($"{NowTime.ToString("yyyy-MM-dd")} 23:59:59"))).ToList();
                            break;
                    }
                }
            }

            if (queryable != null)
            {
                list = queryable.Select(x => new GetCouponsResponse
                {
                    Id = x.c.Id,
                    CouponName = x.c.Name,

                    CouponType = x.mal.Type,
                    CouponTypeName = x.mal.Type == 1 ? "一般Coupon"
                                                        : x.mal.Type == 2 ? "專屬生日禮"
                                                                        : x.mal.Type == 3 ? "升等會員購物禮"
                                                                                            : x.mal.Type == 4 ? "續訂禮"
                                                                                                            : x.mal.Type == 5 ? "訂閱費折抵"
                                                                                                                                : x.mal.Type == 6 ? "滿件折"
                                                                                                                                                : "",
                    MarketingActivityStartDate = x.mal.StartDate.ToString("yyyy/MM/dd"),
                    MarketingActivityEndDate = x.mal.EndDate.ToString("yyyy/MM/dd"),

                    //CanUseStartDate = x.mal.CanUseStartDate?.ToString("yyyy/MM/dd"),
                    //CanUseEndDate = x.mal.CanUseEndDate?.ToString("yyyy/MM/dd"),
                    CanUseStartDate = x.c.StartDate?.ToString("yyyy/MM/dd"),
                    CanUseEndDate = x.c.EndDate?.ToString("yyyy/MM/dd"),

                    CartType = x.cr.CartType,
                 
                    DiscountTarget = x.cr.DiscountTarget,
                    DiscountTargetName = x.cr.DiscountTarget == 1 ? "商品總金額" : "",

                    DiscountContentType = x.cr.DiscountContentType,
                    DiscountContentTypeName = x.cr.DiscountContentType == 1 ? "折" + x.cr.DiscountContentValue.ToString() + "元"
                                                                            : x.cr.DiscountContentType == 2 ? "打" + x.cr.DiscountContentValue.ToString() + "折" : "",
                    DiscountContentValue = x.cr.DiscountContentValue,


                    //Status = (x.mal.CanUseStartDate.HasValue && x.mal.CanUseStartDate > NowTime) && (x.mal.CanUseEndDate.HasValue && x.mal.CanUseEndDate > NowTime) ? "尚未開始"
                    //   : (x.mal.CanUseStartDate.HasValue && x.mal.CanUseStartDate <= NowTime) && (x.mal.CanUseEndDate.HasValue && x.mal.CanUseEndDate >= NowTime) ? "進行中"
                    //   : (x.mal.CanUseStartDate.HasValue && x.mal.CanUseStartDate < NowTime) && (x.mal.CanUseEndDate.HasValue && x.mal.CanUseEndDate < NowTime) ? "已結束" : ""
                    Status = (x.c.StartDate.HasValue && x.c.StartDate > NowTime) && (x.c.EndDate.HasValue && x.c.EndDate > NowTime) ? "尚未開始"
                        : (x.c.StartDate.HasValue && x.c.StartDate <= NowTime) && (x.c.EndDate.HasValue && x.c.EndDate >= NowTime) ? "進行中"
                        : (x.c.StartDate.HasValue && x.c.StartDate < NowTime) && (x.c.EndDate.HasValue && x.c.EndDate < NowTime) ? "已結束" : ""

                }).ToList();
            }
         
            return await Task.FromResult(list);
        }
    }
}
