using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBooks
{
    public class GetStyleBooksQuery : IRequest<Result<GetStyleBooksResponse>>
    {
        /// <summary>
        /// 搭配師
        /// </summary>
        [SwaggerParameter(Description = "搭配師")]
        public string Matchmaker { get; set; }
        /// <summary>
        /// 風格
        /// </summary>
        [SwaggerParameter(Description = "風格")]
        public string Style { get; set; }
        /// <summary>
        /// 場景
        /// </summary>
        [SwaggerParameter(Description = "場景")]
        public string Occasion { get; set; }
        /// <summary>
        /// 1: 已上傳 2:未上傳
        /// </summary>
        [SwaggerParameter(Description = "穿搭照 1: 已上傳 2:未上傳")]
        public int? ImageType { get; set; }
    }

    public class GetStyleBooksQueryHandler : IRequestHandler<GetStyleBooksQuery, Result<GetStyleBooksResponse>>
    {
        private readonly ProductSettings _productSettings;
        private readonly CommonSettings _commonSettings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetStyleBooksQueryHandler(
            IOptions<ProductSettings> productSettings,
            IOptions<CommonSettings> commonSettings, IMapper mapper, IBoxDbContext context)
        {
            _productSettings = productSettings.Value;
            _commonSettings = commonSettings.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<GetStyleBooksResponse>> Handle(GetStyleBooksQuery command, CancellationToken cancellationToken)
        {
            var queryable = _context.StyleBooks.AsQueryable();

            var matchmaker = (command.Matchmaker ?? "")
                .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Guid.Parse(s))
                .ToList();

            var style = (command.Style ?? "")
                .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Guid.Parse(s))
                .ToList();

            var occasion = (command.Occasion ?? "")
                .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Guid.Parse(s))
                .ToList();

            var imageQuery = (command.ImageType ?? 0); // 穿搭照上傳

            if (matchmaker.Any())
            {
                queryable = queryable.Where(a => matchmaker.Contains(a.MatchmakerInfoId));
            }

            if (style.Any())
            {
                queryable = queryable.Where(a => style.Contains(a.StyleId));
            }

            if (occasion.Any())
            {
                queryable = queryable.Where(a => occasion.Contains(a.OccasionId));
            }

            if (imageQuery > 0)
            {
                if (command.ImageType.Value == 1)
                {
                    queryable = queryable.Where(a => a.ImageUrl != "");
                }
                else
                {
                    queryable = queryable.Where(a => a.ImageUrl == "");
                }
            }

            var stylebooks = await queryable
                .Include(s => s.StyleBookDetails)
                .ToListAsync(cancellationToken);

            var styleList = await _context.StyleBookConditions.Where(a => a.Type == 1).ToListAsync(cancellationToken);
            var occasionList = await _context.StyleBookConditions.Where(a => a.Type == 2).ToListAsync(cancellationToken);
            var matchmakers = await _context.MatchmakerInfos.ToListAsync(cancellationToken);

            var mappedStylebookItems = _mapper.Map<List<StyleBookListItem>>(stylebooks);

            foreach (var mapped in mappedStylebookItems)
            {
                // 圖片完整路徑
                mapped.ImageUrl = string.IsNullOrEmpty(mapped.ImageUrl) ? "" : _commonSettings.BoxImageUrl + mapped.ImageUrl;

                mapped.Style = styleList.SingleOrDefault(a => a.Id == mapped.StyleId)?.Name ?? "";
                mapped.Occasion = occasionList.SingleOrDefault(a => a.Id == mapped.OccasionId)?.Name ?? "";
                mapped.Matchmaker = matchmakers.SingleOrDefault(a => a.Id == mapped.MatchmakerInfoId)?.Name ?? "";
                mapped.ColorImage =
                    stylebooks
                        .Single(a => a.Id == mapped.Id)
                        .StyleBookDetails
                        .Where(a => a.ImageUrl != string.Empty)
                        .Select(a => $"{_productSettings.ImageUrl}{a.ImageUrl}")
                        .ToList();
            }

            // 風格總數
            var styleCounts = mappedStylebookItems.GroupBy(y => new { y.StyleId, y.Style }).Select(g => new StyleCount 
            { 
                StyleId = g.Key.StyleId,
                Name = g.Key.Style,
                Count = g.Count()
            }).ToList();

            return Result<GetStyleBooksResponse>.Success(new GetStyleBooksResponse() { Items = mappedStylebookItems, StyleCounts = styleCounts });
        }
    }
}
