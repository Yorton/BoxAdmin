using AutoMapper;
using BoxAdmin.Application.DTOs.Settings;
using BoxAdmin.Application.Interfaces.Contexts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductByFavorites
{
    /// <summary>
    /// 收藏清單
    /// </summary>
    public class GetProductByFavoritesQuery : IRequest<GetProductByFavoritesResponse>
    {
        /// <summary>
        /// 會員ID
        /// </summary>
        public Guid Id { get; set; }

        public class GetProductByFavoritesQueryHandler : IRequestHandler<GetProductByFavoritesQuery, GetProductByFavoritesResponse>
        {
            private readonly ProductSettings _productSettings;
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IBoxDbContext _context;

            public GetProductByFavoritesQueryHandler(IOptions<ProductSettings> productSettings, IMediator mediator, IMapper mapper, IBoxDbContext context)
            {
                _productSettings = productSettings.Value;
                _mediator = mediator;
                _mapper = mapper;
                _context = context;
            }

            public async Task<GetProductByFavoritesResponse> Handle(GetProductByFavoritesQuery command, CancellationToken cancellationToken)
            {
                var responseObject = new GetProductByFavoritesResponse
                {
                    Id = command.Id
                };
                var productFavoriteData = _context.ProductFavorites.Where(w => w.CustomerId == command.Id).ToList();
                if (productFavoriteData != null && productFavoriteData.Count > 0)
                {
                    var ProductItemList = new List<ProductItem>();
                    foreach (var item in productFavoriteData)
                    {
                        var datas = _context.ProductSkus.Where(w => w.Series == item.Series).OrderBy(ob => ob.Sku).ToList();
                        if (datas != null && datas.Count > 0)
                        {
                            var dataInfo = _context.ProductSeries.Where(w => w.Series == item.Series).SingleOrDefault();
                            foreach (var data in datas)
                            {
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
