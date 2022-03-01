using AutoMapper;
using BoxAdmin.Application.DTOs.Settings;
using BoxAdmin.Application.Interfaces.Contexts;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductByScore
{
    /// <summary>
    /// 會員猜你喜歡
    /// </summary>
    public class GetProductByScoreQuery : IRequest<GetProductByScoreResponse>
    {
        public Guid Id { get; set; }

        public class GetProductByScoreQueryHandler : IRequestHandler<GetProductByScoreQuery, GetProductByScoreResponse>
        {
            private readonly ProductSettings _productSettings;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IBoxDbContext _context;

            public GetProductByScoreQueryHandler(IOptions<ProductSettings> productSettings, IMediator mediator, IMapper mapper, IBoxDbContext context)
            {
                _productSettings = productSettings.Value;
                _mediator = mediator;
                _mapper = mapper;
                _context = context;
            }

            public async Task<GetProductByScoreResponse> Handle(GetProductByScoreQuery command, CancellationToken cancellationToken)
            {
                var responseObject = new GetProductByScoreResponse
                {
                    Id = command.Id
                };
                var productScoreData = _context.ProductScores.Where(w => w.CustomerId == command.Id && w.Score == 1).ToList();
                if (productScoreData != null && productScoreData.Count > 0)
                {
                    var ProductItemList = new List<ProductItem>();
                    foreach (var item in productScoreData)
                    {
                        var datas = _context.ProductSkus.Where(w => w.Sku == item.Sku).OrderBy(ob => ob.Sku).ToList();
                        if (datas != null && datas.Count > 0)
                        {                          
                            foreach (var data in datas)
                            {
                                var dataInfo = _context.ProductSeries.Where(w => w.Series == data.Series).SingleOrDefault();
                                var imgData = _context.ProductImages.Where(w => w.Series == data.Series && w.Color == data.Color && w.Type == 2).OrderBy(ob => ob.Sort).FirstOrDefault();
                                var image = imgData != null && !string.IsNullOrWhiteSpace(imgData.ImagePath) && !string.IsNullOrWhiteSpace(imgData.Filename) ? _productSettings.ImageUrl + imgData.ImagePath + imgData.Filename : "";
                                var name = dataInfo != null && !string.IsNullOrWhiteSpace(dataInfo.Name) ? dataInfo.Name : "";
                                ProductItemList.Add(new ProductItem
                                {
                                    Sku = data.Sku,
                                    Series = data.Series,
                                    Size = data.Size,
                                    Color = data.Color,
                                    Name = name,
                                    Image = image,
                                    Price = data.SellingPrice,
                                    Weight = data.Weight,
                                    Stock = data.Stock,
                                    PreStock = data.PreStock
                                });
                            }
                        }
                    }
                    if (ProductItemList != null && ProductItemList.Count > 0)
                    {
                        responseObject.Items = ProductItemList;
                    }
                }
                return await Task.FromResult(responseObject);
            }
        }
    }
}
