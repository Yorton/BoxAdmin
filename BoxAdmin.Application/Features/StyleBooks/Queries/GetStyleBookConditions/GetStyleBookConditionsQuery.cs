using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;

namespace BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBookConditions
{
    public class GetStyleBookConditionsQuery : IRequest<Result<GetStyleBookConditionsResponse>>
    {
        public int Type { get; set; }
    }

    public class GetStyleBookConditionsQueryHandler : IRequestHandler<GetStyleBookConditionsQuery, Result<GetStyleBookConditionsResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetStyleBookConditionsQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<GetStyleBookConditionsResponse>> Handle(GetStyleBookConditionsQuery command, CancellationToken cancellationToken)
        {
            var result = await _context.StyleBookConditions
                .Where(a => a.Type == command.Type)
                .ToListAsync(cancellationToken: cancellationToken);

            var mappedStyleBookConditionItem = _mapper.Map<List<StyleBookConditionItem>>(result);

            return Result<GetStyleBookConditionsResponse>.Success(new GetStyleBookConditionsResponse() { Items = mappedStyleBookConditionItem });
        }
    }
}
