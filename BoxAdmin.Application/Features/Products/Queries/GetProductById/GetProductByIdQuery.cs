using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductById
{
    using BoxAdmin.Application.DTOs.Settings;
    using BoxAdmin.Application.Interfaces.Contexts;

    public class GetProductByIdQuery : IRequest<GetProductByIdResponse>
    {
        public string SeriesNo { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly ProductSettings _productSettings;

        public GetProductByIdQueryHandler(IMapper mapper, IBoxDbContext context, IOptions<ProductSettings> productSettings)
        {
            _mapper = mapper;
            _context = context;
            _productSettings = productSettings.Value;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery command, CancellationToken cancellationToken)
        {
            var responseObject = new GetProductByIdResponse();

            var productSeriesQuery = await _context.ProductSeries.SingleOrDefaultAsync(a => a.Series == command.SeriesNo) 
                ?? throw new Exception($"{command.SeriesNo} 查無資料");

            // 主檔
            responseObject = _mapper.Map<GetProductByIdResponse>(productSeriesQuery);

            // 商品明細
            var skusQuery = await _context.ProductSkus.Where(a => a.Series == command.SeriesNo).ToListAsync();
            foreach(var skuQuery in skusQuery)
            {
                var skuItem = _mapper.Map<GetProductById_ProductSkuItem>(skuQuery);
                responseObject.Items.Add(skuItem);
            }

            // 商品圖片
            var colorImagesQuery = await _context.ProductImages.Where(x => x.Series == command.SeriesNo && x.Type == 2 && x.Color != string.Empty).ToListAsync();
            foreach(var colorImage in colorImagesQuery)
            {
                responseObject.ColorImages.Add(new GetProductById_ProductColorImage()
                {
                    Series = colorImage.Series,
                    Color = colorImage.Color,
                    ImageUrl = $"{_productSettings.ImageUrl}{colorImage.ImagePath}{colorImage.Filename}"
                });
            }

            // 試穿報告

            return await Task.FromResult(responseObject);
        }
    }
}
