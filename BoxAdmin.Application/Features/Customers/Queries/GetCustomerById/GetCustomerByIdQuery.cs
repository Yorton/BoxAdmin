using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.Customers.Queries.GetCustomerById
{
    using BoxAdmin.Application.Interfaces.Contexts;

    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdResponse>
    {
        public Guid Id { get; set; }

        public class GetReservationQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IBoxDbContext _context;

            public GetReservationQueryHandler(IMapper mapper, IBoxDbContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdQuery command, CancellationToken cancellationToken)
            {
                var customerObject = new GetCustomerByIdResponse();

                var customerQuery = await _context.CustomerInfos.FirstOrDefaultAsync(a => a.CustomerId == command.Id, cancellationToken)
                    ?? throw new Exception("查無資料");

                customerObject = _mapper.Map<GetCustomerByIdResponse>(customerQuery);

                return customerObject;
            }
        }
    }
}
