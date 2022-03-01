using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Coupons.Commands.CouponRemove
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using System.Threading;

    public class CouponRemoveCommand : IRequest<CouponRemoveResponse>
    {
        /// <summary>
        /// Coupon ID
        /// </summary>
        [SwaggerParameter(Description = "Coupon ID")]
        public string Id { get; set; }
    }
    
    public class CouponRemoveCommandHandler : IRequestHandler<CouponRemoveCommand, CouponRemoveResponse> 
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        
        public CouponRemoveCommandHandler(IMediator mediator, IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<CouponRemoveResponse> Handle(CouponRemoveCommand command, CancellationToken cancellationToken)
        {
            var response = new CouponRemoveResponse();
          
            using (var dbtc = _context.BeginTransaction)
            {
                try
                {
                    Coupon coupon = _context.Coupons.SingleOrDefault(a => a.Id == command.Id);

                    if (coupon != null)
                    {
                        Guid? marketingActivitiesId = coupon.MarketingActivitiesId;
                        Guid couponRuleId = coupon.CouponRuleId;

                        _context.Coupons.Remove(coupon);
                        await _context.SaveChangesAsync(cancellationToken);

                        int CouponCount = _context.Coupons.Where(x => x.MarketingActivitiesId == marketingActivitiesId).Count();
                        if (CouponCount == 0)//若Coupon移除後,沒有資料,將主檔CouponRule, MarketingActivities一併刪除
                        {
                            CouponRule couponRule = _context.CouponRules.SingleOrDefault(a => a.Id == couponRuleId);
                            MarketingActivities marketingActivity = _context.MarketingActivities.SingleOrDefault(a => a.Id == marketingActivitiesId);

                            _context.CouponRules.Remove(couponRule);
                            _context.MarketingActivities.Remove(marketingActivity);
                            await _context.SaveChangesAsync(cancellationToken);
                        }
                        else //若Coupon移除後,還有資料,更新限量張數
                        {
                            MarketingActivities marketingActivity = _context.MarketingActivities.SingleOrDefault(a => a.Id == marketingActivitiesId);
                            marketingActivity.LimitQuantity = CouponCount;
                            await _context.SaveChangesAsync(cancellationToken);
                        }

                        dbtc.Commit();

                        response.Message = "刪除成功";
                    }
                }
                catch (Exception ex)
                {
                    dbtc.Rollback();

                    response.Message = ex.Message;
                }
            }

            return response;
        }

    }
}
