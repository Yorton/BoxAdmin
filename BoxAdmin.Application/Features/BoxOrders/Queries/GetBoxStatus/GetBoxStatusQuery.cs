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

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxStatus
{
    //public class GetBoxStatusQuery : IRequest<Result<List<GetBoxStatusResponse>>>
    public class GetBoxStatusQuery : IRequest<List<GetBoxStatusResponse>>
    {
    }

    //public class GetBoxStatusQueryHandler : IRequestHandler<GetBoxStatusQuery, Result<List<GetBoxStatusResponse>>> 
    public class GetBoxStatusQueryHandler : IRequestHandler<GetBoxStatusQuery, List<GetBoxStatusResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        
        public GetBoxStatusQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<List<GetBoxStatusResponse>>> Handle(GetBoxStatusQuery command, CancellationToken cancellationToken)
        public async Task<List<GetBoxStatusResponse>> Handle(GetBoxStatusQuery command, CancellationToken cancellationToken)
        {
            List<GetBoxStatusResponse> list = null;

            var queryable = await (from rs in _context.ReservationStates
                                    select new
                                    {
                                        Id = rs.Id,
                                        Name = rs.Title
                                    }).ToListAsync(cancellationToken);
          
            if (queryable != null)
            {
                list = queryable.Select(x => new GetBoxStatusResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
           
            return await Task.FromResult(list);
        }
    }
}
