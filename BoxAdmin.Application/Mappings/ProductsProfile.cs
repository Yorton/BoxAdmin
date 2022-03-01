using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BoxAdmin.Application.Mappings
{
    using BoxAdmin.Domain.Entities.BoxContext;
    using BoxAdmin.Application.Features.Products.Commands.CreateProduct;
    using BoxAdmin.Application.Features.Products.Queries;
    using BoxAdmin.Application.Features.Products.Queries.GetProductById;

    internal class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<CreateProductSeriesDto, ProductSeries>()
                .ForMember(dst => dst.Series, opt => opt.MapFrom(o => o.SeriesNo))
                .ReverseMap();
            CreateMap<CreateProductItemDto, ProductSku>()
                .ReverseMap();
            CreateMap<ProductSeries, GetProductByIdResponse>()
                .ForMember(dst => dst.Description, opt => opt.MapFrom(d => d.Description))
                .ForMember(dst => dst.Brand, opt => opt.MapFrom(d => d.Brand ?? string.Empty))
                .ForMember(dst => dst.Material, opt => opt.MapFrom(d => d.Material ?? string.Empty))
                .ReverseMap();
            CreateMap<ProductSku, GetProductById_ProductSkuItem>()
                .ReverseMap();
            CreateMap<ProductSku, ProductItem>()
                .ForMember(dst => dst.Price, opt => opt.MapFrom(d => $"{d.SellingPrice}"))
                .ReverseMap();
        }
    }
}
