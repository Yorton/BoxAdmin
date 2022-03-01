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

namespace BoxAdmin.Application.Features.Products.Queries.GetProductBySku
{
    using BoxAdmin.Application.DTOs.Settings;
    using BoxAdmin.Application.Interfaces.Contexts;

    public class GetProductBySkuQuery : IRequest<GetProductBySkuResponse>
    {
        public string Sku { get; set; }
    }

    public class GetProductBySkuQueryHandler : IRequestHandler<GetProductBySkuQuery, GetProductBySkuResponse>
    {
        private readonly ProductSettings _productSettings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetProductBySkuQueryHandler(IOptions<ProductSettings> productSettings, IMapper mapper, IBoxDbContext context)
        {
            _productSettings = productSettings.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetProductBySkuResponse> Handle(GetProductBySkuQuery command, CancellationToken cancellationToken)
        {
            var response = new GetProductBySkuResponse();
            var sku = command.Sku;

            var productSkuQuery = await _context.ProductSkus.SingleOrDefaultAsync(x => x.Sku == sku, cancellationToken)
                ?? throw new ArgumentException("查無資料", $"{nameof(command.Sku)}");

            var productSeriesQuery = await _context.ProductSeries.SingleOrDefaultAsync(x => x.Series == productSkuQuery.Series);

            var colorImagesQuery = await _context.ProductImages
                .Where(x => x.Series == productSeriesQuery.Series && x.Type == 2 && x.Color == productSkuQuery.Color)
                .Select(x => new
                {
                    Color = x.Color,
                    ImageUrl = $"{_productSettings.ImageUrl}{x.ImagePath}{x.Filename}"
                })
                .FirstOrDefaultAsync(cancellationToken);

            response.Info = _mapper.Map<ProductItem>(productSkuQuery);
            response.Info.Name = productSeriesQuery.Name;
            response.Info.Image = colorImagesQuery?.ImageUrl ?? string.Empty;

            //foreach (var item in productSkuQuery)
            //{
            //    var mappedProductSku = _mapper.Map<ProductItem>(item);
            //    mappedProductSku.Name = productSeriesQuery.Name;

            //    var skuColorImage = colorImagesQuery.FirstOrDefault(x => x.Color == mappedProductSku.Color);
            //    mappedProductSku.Image = skuColorImage?.ImageUrl ?? string.Empty;

            //    response.Items.Add(mappedProductSku);
            //}

            return response;
        }
    }

    public class GetProductBySkuResponse
    {
        [SwaggerSchema("商品SKU")] public ProductItem Info { get; set; }
    }
}
