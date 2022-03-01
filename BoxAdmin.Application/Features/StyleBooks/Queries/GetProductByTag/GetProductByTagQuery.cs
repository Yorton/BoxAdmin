using AutoMapper;
using BoxAdmin.Application.DTOs.Settings;
using BoxAdmin.Application.Features.Products.Queries;
using BoxAdmin.Application.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.StyleBooks.Queries.GetProductByTag
{
    public class GetProductByTagQuery : IRequest<GetProductByTagResponse>
    {
        /// <summary>
        /// 類型
        /// </summary>
        [SwaggerParameter(Description = "類型")]
        public string Type { get; set; }

        /// <summary>
        /// 顏色
        /// </summary>
        [SwaggerParameter(Description = "顏色")]
        public string Color { get; set; }

        /// <summary>
        /// 寬鬆度
        /// </summary>
        [SwaggerParameter(Description = "寬鬆度")]
        public string Tightness { get; set; }

        /// <summary>
        /// 長度
        /// </summary>
        [SwaggerParameter(Description = "長度")]
        public string Length { get; set; }
    }

    public class GetProductByTagQueryHandler : IRequestHandler<GetProductByTagQuery, GetProductByTagResponse>
    {
        private readonly ProductSettings _productSettings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetProductByTagQueryHandler(IOptions<ProductSettings> productSettings, IMapper mapper, IBoxDbContext context)
        {
            _productSettings = productSettings.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetProductByTagResponse> Handle(GetProductByTagQuery command, CancellationToken cancellationToken)
        {
            var seriesList = _context.ProductTagToSeries.Where(x => x.TagCode == command.Type).Select(y => y.SeriesNo);

            if (!string.IsNullOrEmpty(command.Tightness))
            {
                var tightnessSeries = _context.ProductTagToSeries.Where(x => x.TagCode == command.Tightness).Select(y => y.SeriesNo);
                seriesList = seriesList.Intersect(tightnessSeries);
            }

            if (!string.IsNullOrEmpty(command.Length))
            {
                var lengthSeries = _context.ProductTagToSeries.Where(x => x.TagCode == command.Length).Select(y => y.SeriesNo);
                seriesList = seriesList.Intersect(lengthSeries);
            }

            var productList = await (from s in _context.ProductSeries
                                     join p in _context.ProductSkus on s.Series equals p.Series
                                     join i in _context.ProductImages on
                                        new { Series = p.Series, Color = p.Color, Type = 2 } equals
                                        new { Series = i.Series, Color = i.Color, Type = i.Type } into g1
                                     from i in g1.DefaultIfEmpty()
                                     where seriesList.Contains(s.Series)
                                     select new ProductItem
                                     {
                                         Sku = p.Sku,
                                         Series = p.Series,
                                         Size = p.Size,
                                         Color = p.Color,
                                         Name = s.Name,
                                         Image = !string.IsNullOrEmpty(i.ImagePath) && !string.IsNullOrEmpty(i.Filename) ? _productSettings.ImageUrl + i.ImagePath + i.Filename : "",
                                         Price = p.SellingPrice,
                                         Weight = p.Weight,
                                         Stock = p.Stock,
                                         PreStock = p.PreStock
                                     }).ToListAsync(cancellationToken);

            var responseObject = new GetProductByTagResponse() { Items = productList };

            return await Task.FromResult(responseObject);
        }
    }
}