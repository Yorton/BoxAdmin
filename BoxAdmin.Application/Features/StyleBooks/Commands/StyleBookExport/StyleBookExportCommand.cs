using AutoMapper;
using BoxAdmin.Application.DTOs.Settings;
using BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBooks;
using BoxAdmin.Application.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookExport
{
    public class StyleBookExportCommand : IRequest<List<ExportItem>>
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

    public class StyleBookExportCommandHandler : IRequestHandler<StyleBookExportCommand, List<ExportItem>>
    {
        private readonly ProductSettings _productSettings;
        private readonly CommonSettings _commonSettings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public StyleBookExportCommandHandler(
            IOptions<ProductSettings> productSettings,
            IOptions<CommonSettings> commonSettings,
            IMapper mapper, IBoxDbContext context)
        {
            _productSettings = productSettings.Value;
            _commonSettings = commonSettings.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<ExportItem>> Handle(StyleBookExportCommand command, CancellationToken cancellationToken)
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

            var i = 1;
            var exportList = new List<ExportItem>();
            foreach (var mapped in mappedStylebookItems)
            {
                var colorImages = stylebooks.Single(a => a.Id == mapped.Id).StyleBookDetails.Where(a => a.ImageUrl != string.Empty).ToList();
                var item = new ExportItem()
                {
                    序號 = i++,
                    穿搭組合照 = !string.IsNullOrEmpty(mapped.ImageUrl) ? _commonSettings.BoxImageUrl + mapped.ImageUrl : "無照片",
                    商品色塊主圖1 = colorImages.Count > 0 ? colorImages[0].Series : "",
                    商品色塊主圖1照片 = colorImages.Count > 0 ? $"{_productSettings.ImageUrl}{colorImages[0].ImageUrl}" : "",
                    商品色塊主圖2 = colorImages.Count > 1 ? colorImages[1].Series : "",
                    商品色塊主圖2照片 = colorImages.Count > 1 ? $"{_productSettings.ImageUrl}{colorImages[1].ImageUrl}" : "",
                    風格分類 = styleList.SingleOrDefault(a => a.Id == mapped.StyleId)?.Name ?? "",
                    情境場合 = occasionList.SingleOrDefault(a => a.Id == mapped.OccasionId)?.Name ?? "",
                    穿搭顧問 = matchmakers.SingleOrDefault(a => a.Id == mapped.MatchmakerInfoId)?.Name ?? "",
                    建立時間 = mapped.CreatedDate,
                    最後異動時間 = mapped.ModifyDate
                };
                exportList.Add(item);
            }

            return exportList;
        }
    }

    public class ExportItem
    { 
        public int 序號 { get; set; }

        public string 穿搭組合照 { get; set; }

        public string 商品色塊主圖1 { get; set; }

        public string 商品色塊主圖1照片 { get; set; }

        public string 商品色塊主圖2 { get; set; }

        public string 商品色塊主圖2照片 { get; set; }

        public string 風格分類 { get; set; }

        public string 情境場合 { get; set; }

        public string 穿搭顧問 { get; set; }

        public DateTime 建立時間 { get; set; }

        public DateTime? 最後異動時間 { get; set; }
    }
}
