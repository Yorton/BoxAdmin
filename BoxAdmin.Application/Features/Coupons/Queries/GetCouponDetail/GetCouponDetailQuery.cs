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
using BoxAdmin.Domain.Entities.BoxContext;

namespace BoxAdmin.Application.Features.Coupons.Queries.GetCouponDetail
{
    //public class GetCouponDetailQuery : IRequest<Result<GetCouponDetailResponse>>
    public class GetCouponDetailQuery : IRequest<GetCouponDetailResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    //public class GetCouponDetailQueryHandler : IRequestHandler<GetCouponDetailQuery, Result<GetCouponDetailResponse>>
    public class GetCouponDetailQueryHandler : IRequestHandler<GetCouponDetailQuery, GetCouponDetailResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetCouponDetailQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        //public async Task<Result<GetCouponDetailResponse>> Handle(GetCouponDetailQuery command, CancellationToken cancellationToken)
        public async Task<GetCouponDetailResponse> Handle(GetCouponDetailQuery command, CancellationToken cancellationToken)
        {
            GetCouponDetailResponse response = new GetCouponDetailResponse();

            DateTime NowTime = DateTime.Now;

            var queryable = await (from c in _context.Coupons
                                  join cr in _context.CouponRules on c.CouponRuleId equals cr.Id
                                  join ma in _context.MarketingActivities on c.MarketingActivitiesId equals ma.Id into maGroup
                                  from mal in maGroup.DefaultIfEmpty()
                                  where cr.Enable == true
                                  select new { c, cr, mal }
                                  ).ToListAsync(cancellationToken);

            if (!string.IsNullOrEmpty(command.Id))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.c.Id == command.Id).ToList();
            }

            if (!string.IsNullOrEmpty(command.Name))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => !string.IsNullOrEmpty(x.c.Name) ? x.c.Name.Contains(command.Name) : false).ToList();
            }

            if (queryable != null)
            {
                response.CouponDetailList = queryable.Select(x => new CouponDetail
                {

                    Id = x.c.Id,
                    Name = x.c.Name,
                    SpecialCode = x.c.SpecialCode,
                    CustomerId = x.c.CustomerId,
                    ReceivedDate = x.c.ReceivedDate?.ToString("yyyy/MM/dd"),

                    //CanUseDate = x.mal.CanUseStartDate.HasValue && x.mal.CanUseEndDate.HasValue 
                    //                ? x.mal.CanUseStartDate?.ToString("yyyy/MM/dd") + " 00:00:00~" + x.mal.CanUseEndDate?.ToString("yyyy/MM/dd") + " 23:59:59"
                    //                : "",
                    CanUseDate = x.c.StartDate.HasValue && x.c.EndDate.HasValue
                                    ? x.c.StartDate?.ToString("yyyy/MM/dd") + " 00:00:00~" + x.c.EndDate?.ToString("yyyy/MM/dd") + " 23:59:59"
                                    : "",

                    UsedDate = x.c.UsedDate?.ToString("yyyy/MM/dd"),
                    TransactionId = x.c.TransactionId

                }).ToList();

                MarketingActivities marketingActivity = queryable.FirstOrDefault().mal;

                string MarketActivitiesStartDate = marketingActivity.StartDate.ToString("yyyy/MM/dd") + " 00:00:00";
                string MarketActivitiesEndDate = marketingActivity.EndDate.ToString("yyyy/MM/dd") + " 23:59:59";
                response.MarketingActivityDate = MarketActivitiesStartDate + "~" + MarketActivitiesEndDate;

                int OutputType = marketingActivity.OutputType;
                response.OutputTypeName = OutputType == 1 ? "即時產出"
                                                          : OutputType == 2 ? "預先產出" : "";

                response.ProducedCount = queryable.Count();
                response.ReceivedCount = queryable.Where(x => x.c.ReceivedDate != null).Count();
                response.UsedCount = queryable.Where(x => x.c.UsedDate != null).Count();
            }
            else response = null;

            //return Result<GetCouponDetailResponse>.Success(response);
            return await Task.FromResult(response);
        }
    }
}
