using AutoMapper;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Framework.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Orders.Queries.GetOrderStates
{
    public class GetOrderStateQuery : IRequest<Result<List<GetOrderStateResponse>>>
    {
    }

    public class GetOrderStateQueryHandler : IRequestHandler<GetOrderStateQuery, Result<List<GetOrderStateResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetOrderStateQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<List<GetOrderStateResponse>>> Handle(GetOrderStateQuery command, CancellationToken cancellationToken)
        {
            List<GetOrderStateResponse> list = null;

            try
            {
                list = await (from s in _context.OrderStates
                              select new GetOrderStateResponse 
                              { 
                                  Text = s.Title,
                                  Value = s.Id
                              }).ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                return Result<List<GetOrderStateResponse>>.Fail(ex.Message);
            }

            return Result<List<GetOrderStateResponse>>.Success(list);

        }
    }
}
