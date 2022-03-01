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

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeState
{
    public class GetSubscribeStateQuery : IRequest<Result<List<GetSubscribeStateResponse>>>
    {

    }

    public class GetSubscribeStateQueryHandler : IRequestHandler<GetSubscribeStateQuery, Result<List<GetSubscribeStateResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetSubscribeStateQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<List<GetSubscribeStateResponse>>> Handle(GetSubscribeStateQuery command, CancellationToken cancellationToken)
        {
            List<GetSubscribeStateResponse> list = null;

            try
            {
                var queryable = await (from rs in _context.SubscribeStates
                                       select new
                                       {
                                           Id = rs.Id,
                                           Name = rs.Title
                                       }).ToListAsync(cancellationToken);

                if (queryable != null)
                {
                    list = queryable.Select(x => new GetSubscribeStateResponse
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return Result<List<GetSubscribeStateResponse>>.Fail(ex.Message);
            }

            return Result<List<GetSubscribeStateResponse>>.Success(list);
        }
    }
}
