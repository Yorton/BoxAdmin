using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.Subscribes.Queries.GetSubscribeById
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.DTOs.Settings;

    public class GetSubscribeByIdQuery : IRequest<GetSubscribeByIdResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetStyleBooksQueryHandler : IRequestHandler<GetSubscribeByIdQuery, GetSubscribeByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetStyleBooksQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetSubscribeByIdResponse> Handle(GetSubscribeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetSubscribeByIdResponse();

            var subscribesQuery = await _context.Subscribes.SingleOrDefaultAsync(a => a.Id == request.Id, cancellationToken: cancellationToken)
                ?? throw new Exception("查無預約單資料");

            response = _mapper.Map<GetSubscribeByIdResponse>(subscribesQuery);

            return await Task.FromResult(response);
        }
    }
}
