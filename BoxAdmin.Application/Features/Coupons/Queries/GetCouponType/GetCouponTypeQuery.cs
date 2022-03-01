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
          

namespace BoxAdmin.Application.Features.Coupons.Queries.GetCouponType
{
    //public class GetCouponTypeQuery : IRequest<Result<List<GetCouponTypeResponse>>>
    public class GetCouponTypeQuery : IRequest<List<GetCouponTypeResponse>>
    {
    }

    //public class GetCouponTypeQueryHandler : IRequestHandler<GetCouponTypeQuery, Result<List<GetCouponTypeResponse>>> 
    public class GetCouponTypeQueryHandler : IRequestHandler<GetCouponTypeQuery, List<GetCouponTypeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetCouponTypeQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<List<GetCouponTypeResponse>>> Handle(GetCouponTypeQuery command, CancellationToken cancellationToken)
        public async Task<List<GetCouponTypeResponse>> Handle(GetCouponTypeQuery command, CancellationToken cancellationToken)
        {
            List<GetCouponTypeResponse> list = new List<GetCouponTypeResponse>();

            list.Add(new GetCouponTypeResponse { 
                CouponType = 1,
                CouponTypeName = "一般COUPON"
            });

            list.Add(new GetCouponTypeResponse
            {
                CouponType = 2,
                CouponTypeName = "專屬生日禮"
            });

            list.Add(new GetCouponTypeResponse
            {
                CouponType = 3,
                CouponTypeName = "升等會員購物禮"
            });

            list.Add(new GetCouponTypeResponse
            {
                CouponType = 4,
                CouponTypeName = "續訂禮"
            });

            list.Add(new GetCouponTypeResponse
            {
                CouponType = 5,
                CouponTypeName = "訂閱費折抵"
            });

            list.Add(new GetCouponTypeResponse
            {
                CouponType = 6,
                CouponTypeName = "滿件折"
            });

            //return Result<List<GetCouponTypeResponse>>.Success(list);
            return await Task.FromResult(list);
        }
    }
}
