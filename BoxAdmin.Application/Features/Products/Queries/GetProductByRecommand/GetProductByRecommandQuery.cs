using AutoMapper;
using BoxAdmin.Application.DTOs.Settings;
using BoxAdmin.Application.Interfaces.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductByRecommand
{

    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Application.DTOs.Infrastructure.Shared;

    /// <summary>
    /// 收藏清單
    /// </summary>
    public class GetProductByRecommandQuery : IRequest<GetProductByRecommandResponse>
    {
        public class GetProductByRecommandQueryHandler : IRequestHandler<GetProductByRecommandQuery, GetProductByRecommandResponse>
        {
            private readonly ProductSettings _productSettings;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IBoxDbContext _context;
            private readonly IISheboxRecommendedService _iSheboxRecommendedService;

            public GetProductByRecommandQueryHandler(IOptions<ProductSettings> productSettings,
                IMediator mediator,
                IMapper mapper,
                IBoxDbContext context,
                IISheboxRecommendedService iSheboxRecommendedService)
            {
                _productSettings = productSettings.Value;
                _mediator = mediator;
                _mapper = mapper;
                _context = context;
                _iSheboxRecommendedService = iSheboxRecommendedService;
            }

            public async Task<GetProductByRecommandResponse> Handle(GetProductByRecommandQuery command, CancellationToken cancellationToken)
            {
                var responseObject = new GetProductByRecommandResponse();

                // 從工研院推薦系API取得的商品清單
                var responseObj = await _iSheboxRecommendedService.GetRecommendedProductItemsAsync(new ISheboxRecommendedGetItemRequest());

                var seriesList = responseObj.RecomdList.Select(x => x.Id.Split('-').Length > 0 ? x.Id.Split('-')[0] : string.Empty).Where(y => !string.IsNullOrEmpty(y)).ToArray();

                var queryable = await (
                    from p in _context.ProductSkus
                    join s in _context.ProductSeries on p.Series equals s.Series
                    join i in _context.ProductImages on
                        new { p.Series, p.Color, Type = 2, Sort = 1 } equals
                        new { i.Series, i.Color, i.Type, i.Sort }
                    where seriesList.Contains(p.Series)
                    select new ProductItem
                    {
                        Sku = p.Sku,
                        Series = p.Series,
                        Size = p.Size,
                        Color = p.Color,
                        Name = s.Name ?? "",
                        Image = !string.IsNullOrWhiteSpace(i.ImagePath) && !string.IsNullOrWhiteSpace(i.Filename) ? _productSettings.ImageUrl + i.ImagePath + i.Filename : "",
                        Price = p.SellingPrice,
                        Weight = p.Weight,
                        Stock = p.Stock,
                        PreStock = p.PreStock
                    }).ToListAsync(cancellationToken);
                responseObject.Items = queryable;

                return await Task.FromResult(responseObject);
            }
        }
    }
}
