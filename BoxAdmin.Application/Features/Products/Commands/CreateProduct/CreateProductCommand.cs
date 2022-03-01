using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.Products.Commands.CreateProduct
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;

    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public CreateProductSeriesDto ProductSeries { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public CreateProductCommandHandler(IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<CreateProductResponse> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var response = new CreateProductResponse();

            var inputProductSeries = command?.ProductSeries ?? throw new NullReferenceException("");

            if (inputProductSeries.Items.Count == 0)
            {
                throw new Exceptions.ApiException("items empty");
            }

            var productSeries = await _context.ProductSeries.SingleOrDefaultAsync(a => a.Series == inputProductSeries.SeriesNo, cancellationToken);

            // 商品主檔
            if (productSeries == null) 
            {
                productSeries = _mapper.Map<ProductSeries>(inputProductSeries);
                productSeries.CreatedDate = DateTime.Now;
                productSeries.FirstSellDate = DateTime.Now;
                productSeries.ModifyDate = DateTime.Now;
                productSeries.Enable = true;
                _context.ProductSeries.Add(productSeries);
            }
            else
            {
                productSeries.Name = inputProductSeries.Name;
                productSeries.Description = inputProductSeries.Description;
                productSeries.OverseasDeliverya = inputProductSeries.OverseasDelivery;
                productSeries.Brand = inputProductSeries.Brand;
                productSeries.Material = inputProductSeries.Material;
                productSeries.Origin = inputProductSeries.Origin;
                productSeries.Color = inputProductSeries.Color;
                productSeries.Accessories = inputProductSeries.Accessories;
                productSeries.Attention = inputProductSeries.Attention;
                productSeries.ModifyDate = DateTime.Now;
            }

            // 商品明細
            foreach(var item in inputProductSeries.Items)
            {
                var sku = await _context.ProductSkus.SingleOrDefaultAsync(p => p.Sku == item.Sku, cancellationToken);
                if (sku == null)
                {
                    sku = _mapper.Map<ProductSku>(item);
                    sku.Enable = true;
                    sku.ModifyDate = DateTime.Now;
                    sku.CreatedDate = DateTime.Now;
                    _context.ProductSkus.Add(sku);
                }
                else
                {
                    //sku = _mapper.Map<ProductSku>(item);
                    sku.Series = item.Series;
                    sku.SubSeries = item.SubSeries;
                    sku.Size = item.Size;
                    sku.Color = item.Color;
                    sku.Stock = item.Stock;
                    sku.SellingPrice = item.SellingPrice;
                    sku.Weight = item.Weight;
                    sku.ModifyDate = DateTime.Now;
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
