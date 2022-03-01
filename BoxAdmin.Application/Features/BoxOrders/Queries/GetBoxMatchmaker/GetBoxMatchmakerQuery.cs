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

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxMatchmaker
{
    //public class GetBoxMatchmakerQuery : IRequest<Result<List<GetBoxMatchmakerResponse>>>
    public class GetBoxMatchmakerQuery : IRequest<List<GetBoxMatchmakerResponse>>
    {
    }

    //public class GetBoxMatchmakerQueryHandler : IRequestHandler<GetBoxMatchmakerQuery, Result<List<GetBoxMatchmakerResponse>>>
    public class GetBoxMatchmakerQueryHandler : IRequestHandler<GetBoxMatchmakerQuery, List<GetBoxMatchmakerResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetBoxMatchmakerQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<List<GetBoxMatchmakerResponse>>> Handle(GetBoxMatchmakerQuery command, CancellationToken cancellationToken)
        public async Task<List<GetBoxMatchmakerResponse>> Handle(GetBoxMatchmakerQuery command, CancellationToken cancellationToken)
        {
            List<GetBoxMatchmakerResponse> list = null;
                      
            var queryable = await (from mi in _context.MatchmakerInfos
                                    select new
                                    {
                                        Id = mi.Id,
                                        Name = mi.Name
                                    }).ToListAsync(cancellationToken);

            if (queryable != null)
            {
                list = queryable.Select(x => new GetBoxMatchmakerResponse
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
            }
         
            return await Task.FromResult(list);
        }
    }
}
