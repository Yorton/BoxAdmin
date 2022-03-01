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

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Application.DTOs.Settings;

namespace BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBookById
{
    public class GetStyleBookByIdQuery : IRequest<GetStyleBookByIdResponse>
    {
        public Guid Id { get; set; }
    }

    public class GetStyleBookByIdQueryHandler : IRequestHandler<GetStyleBookByIdQuery, GetStyleBookByIdResponse>
    {
        private readonly CommonSettings _commonSettings;
        private readonly ProductSettings _productSettings;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetStyleBookByIdQueryHandler(
            IOptions<ProductSettings> productSettings,
            IOptions<CommonSettings> commonSettings,
            IMediator mediator,
            IMapper mapper,
            IBoxDbContext context)
        {
            _productSettings = productSettings.Value;
            _commonSettings = commonSettings.Value;
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetStyleBookByIdResponse> Handle(GetStyleBookByIdQuery command, CancellationToken cancellationToken)
        {
            var stylebookQuery = await _context.StyleBooks
                .Where(a => a.Id == command.Id)
                .Include(s => s.StyleBookDetails)
                .SingleOrDefaultAsync(cancellationToken);

            var mappingStylebook = _mapper.Map<GetStyleBookByIdResponse>(stylebookQuery);

            // 回傳圖片完整路徑
            mappingStylebook.ImageUrl = string.IsNullOrEmpty(mappingStylebook.ImageUrl) ? 
                string.Empty : 
                $"{_commonSettings.BoxImageUrl}{stylebookQuery.ImageUrl}";

            foreach (var productItem in stylebookQuery.StyleBookDetails)
            {
                productItem.ImageUrl = string.IsNullOrEmpty(productItem.ImageUrl) ?
                    string.Empty :
                    $"{_productSettings.ImageUrl}{productItem.ImageUrl}";

                mappingStylebook.Items.Add(_mapper.Map<StyleBookProduct>(productItem));
            }

            var matchmakerQuery = await _context.MatchmakerInfos.SingleOrDefaultAsync(a => a.Id == stylebookQuery.MatchmakerInfoId);

            mappingStylebook.Matchmaker = _mapper.Map<Matchmaker>(matchmakerQuery);

            return await Task.FromResult(mappingStylebook);
        }
    }
}
