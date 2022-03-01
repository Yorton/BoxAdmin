using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductBySeriesNo
{
    using BoxAdmin.Application.DTOs.Settings;
    using BoxAdmin.Application.Interfaces.Contexts;

    public class GetProductBySeriesNoQuery : IRequest<GetProductBySeriesNoResponse>
    {
        public string SeriesNo { get; set; }
    }

    public class GetProductBySeriesNoQueryHandler : IRequestHandler<GetProductBySeriesNoQuery, GetProductBySeriesNoResponse>
    {
        private readonly ProductSettings _productSettings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetProductBySeriesNoQueryHandler(IOptions<ProductSettings> productSettings, IMapper mapper, IBoxDbContext context)
        {
            _productSettings = productSettings.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetProductBySeriesNoResponse> Handle(GetProductBySeriesNoQuery command, CancellationToken cancellationToken)
        {
            var response = new GetProductBySeriesNoResponse();
            var seriesNo = command.SeriesNo;

            var productSeriesQuery = await _context.ProductSeries.SingleOrDefaultAsync(x => x.Series == seriesNo, cancellationToken);

            var productSkuQuery = await _context.ProductSkus
                .Where(x => x.Series == seriesNo)
                .ToListAsync(cancellationToken);

            var colorImagesQuery = await _context.ProductImages
                .Where(x => x.Series == seriesNo && x.Type == 2 && x.Color != string.Empty)
                .Select(x => new
                {
                    Color = x.Color,
                    ImageUrl = $"{_productSettings.ImageUrl}{x.ImagePath}{x.Filename}"
                })
                .ToListAsync(cancellationToken);

            response.SeriesNo = productSeriesQuery.Series;
            foreach (var item in productSkuQuery)
            {
                var mappedProductSku = _mapper.Map<ProductItem>(item);
                mappedProductSku.Name = productSeriesQuery.Name;

                var skuColorImage = colorImagesQuery.FirstOrDefault(x => x.Color == mappedProductSku.Color);
                mappedProductSku.Image = skuColorImage?.ImageUrl ?? string.Empty;

                response.Items.Add(mappedProductSku);
            }

            return response;
        }
    }
}
