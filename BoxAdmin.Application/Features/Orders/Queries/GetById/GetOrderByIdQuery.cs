using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;

namespace BoxAdmin.Application.Features.Orders.Queries.GetById
{
    public class GetOrderByIdQuery : IRequest<Result<GetOrderByIdResponse>>
    {
        public GetOrderByIdQuery() { }
    }

    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetOrderByIdQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<GetOrderByIdResponse>> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var mappedOrder = _mapper.Map<GetOrderByIdResponse>(new GetOrderByIdResponse() { Id = "1" });
            throw new BoxAdmin.Application.Exceptions.ApiException("xxxxxxxx");
            return Result<GetOrderByIdResponse>.Success(await Task.FromResult(mappedOrder));
        }
    }
}
