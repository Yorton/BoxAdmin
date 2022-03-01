using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Application.DTOs.Settings;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxCustomerTitle
{
    //public class GetBoxCustomerTitleQuery : IRequest<Result<GetBoxCustomerTitleResponse>>
    public class GetBoxCustomerTitleQuery : IRequest<GetBoxCustomerTitleResponse>
    {
        /// <summary>
        /// BOX訂閱盒編號
        /// </summary>
        [SwaggerParameter(Description = "BOX訂閱盒編號")]
        public string BoxNo { get; set; }
    }

    //public class GetBoxCustomerTitleQueryHandler : IRequestHandler<GetBoxCustomerTitleQuery, Result<GetBoxCustomerTitleResponse>>
    public class GetBoxCustomerTitleQueryHandler : IRequestHandler<GetBoxCustomerTitleQuery, GetBoxCustomerTitleResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetBoxCustomerTitleQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<GetBoxCustomerTitleResponse>> Handle(GetBoxCustomerTitleQuery command, CancellationToken cancellationToken)
        public async Task<GetBoxCustomerTitleResponse> Handle(GetBoxCustomerTitleQuery command, CancellationToken cancellationToken)
        {
            GetBoxCustomerTitleResponse response = null;
                       
            var queryable = await (from c in _context.Reservations
                                    join s in _context.Subscribes on c.SubscribeId equals s.Id into csGroup
                                    from cs in csGroup.DefaultIfEmpty()
                                    join sp in _context.SubscriptionPlanInfos on cs.SubscriptionPlanId equals sp.Id into spcsGroup
                                    from spcs in spcsGroup.DefaultIfEmpty()
                                    join ci in _context.CustomerInfos on c.CustomerId equals ci.CustomerId into cciGroup
                                    from cci in cciGroup.DefaultIfEmpty()
                                    where c.BoxNo == command.BoxNo
                                    select new
                                    {
                                        CustomerId = cci.CustomerId,
                                        CustomerName = cci.Name,
                                        SubscribeTypeName = spcs.Type == 1 ? "季" 
                                                                           : spcs.Type == 2 ? "月"
                                                                           : spcs.Type == 3 ? "年" : "", 
                                        DueDate = cs.DueDate.ToString("yyyy/MM/dd")
                                    }).ToListAsync(cancellationToken);


            response = queryable.Select(x => new GetBoxCustomerTitleResponse
            {
                    CustomerId = x.CustomerId,
                    CustomerName = x.CustomerName,
                    SubscribeTypeName = x.SubscribeTypeName,
                    DueDate = x.DueDate
            }).FirstOrDefault();
         
            return await Task.FromResult(response);
        }
    }
}
