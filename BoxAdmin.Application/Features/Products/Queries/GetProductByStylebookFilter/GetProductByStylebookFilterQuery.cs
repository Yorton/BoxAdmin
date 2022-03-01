using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using AutoMapper;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductByStylebookFilter
{
    using BoxAdmin.Application.DTOs.Settings;
    using BoxAdmin.Application.Interfaces.Contexts;

    public class GetProductByStylebookFilterQuery : IRequest<GetProductByStylebookFilterResponse>
    {
        [SwaggerSchema("商品款號")] public string Series { get; set; }
        [SwaggerSchema("顏色")] public string Color { get; set; }
    }

    public class GetProductByStylebookFilterQueryHandler : IRequestHandler<GetProductByStylebookFilterQuery, GetProductByStylebookFilterResponse>
    {
        private readonly ProductSettings _productSettings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetProductByStylebookFilterQueryHandler(IOptions<ProductSettings> productSettings, IMapper mapper, IBoxDbContext context)
        {
            _productSettings = productSettings.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetProductByStylebookFilterResponse> Handle(GetProductByStylebookFilterQuery command, CancellationToken cancellationToken)
        {
            var inputSeriesNo = command.Series ?? throw new ArgumentException("款號不能為空白", $"{nameof(command.Series)}");
            var inputColor = command.Color ?? throw new ArgumentException("顏色不能為空白", $"{nameof(command.Color)}");

            var styleBookIdsQuery = await _context.StyleBookDetails
                .Where(x => x.Series == inputSeriesNo && x.Color == inputColor)
                .Select(x => x.StyleBookId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var productItemsQuery = await (
                from sb in _context.StyleBooks
                join sbd in _context.StyleBookDetails on sb.Id equals sbd.StyleBookId
                join p in _context.ProductSkus on new { sbd.Series, sbd.Color }  equals new { p.Series, p.Color }
                join ps in _context.ProductSeries on p.Series equals ps.Series
                where styleBookIdsQuery.Contains(sb.Id)
                select new 
                {
                    ProductSku = p,
                    ProductSeries = ps
                }).ToListAsync(cancellationToken);

            var response = new GetProductByStylebookFilterResponse();

            foreach(var pitem in productItemsQuery)
            {
                var mappedProductSku = _mapper.Map<ProductItem>(pitem.ProductSku);
                mappedProductSku.Name = pitem.ProductSeries.Name;

                // ColorImage
                var colorImageQuery = await _context.ProductImages
                    .Where(x => x.Series == mappedProductSku.Series && x.Type == 2 && x.Color == pitem.ProductSku.Color)
                    .Select(x => $"{_productSettings.ImageUrl}{x.ImagePath}{x.Filename}")
                    .FirstOrDefaultAsync(cancellationToken);
                mappedProductSku.Image = colorImageQuery ?? string.Empty;

                response.Items.Add(mappedProductSku);
            }

            return response;
        }
    }

    public class GetProductByStylebookFilterResponse
    {
        [SwaggerSchema("商品SKU")] public List<ProductItem> Items { get; set; } = new List<ProductItem>();
    }
}
