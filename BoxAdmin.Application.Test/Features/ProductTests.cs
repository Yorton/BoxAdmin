using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Xunit;
using MediatR;

namespace BoxAdmin.Application.Test
{
    using BoxContext = Domain.Entities.BoxContext;
    using BoxAdmin.Application.Interfaces.Contexts;
    using CreateProductCommand = BoxAdmin.Application.Features.Products.Commands.CreateProduct;
    using GetProductByIdQuery = BoxAdmin.Application.Features.Products.Queries.GetProductById;

    public class ProductTests
    {
        private readonly IMediator _mediator;
        private readonly IBoxDbContext _context;
        public ProductTests(IMediator mediator, IBoxDbContext context)
        {
            _mediator = mediator;
            _context = context;

            // Fake Data
            _context.ProductSeries.Add(new BoxContext.ProductSeries()
            {
                Series = "IR0021"
            });

            _context.ProductSkus.Add(new BoxContext.ProductSku() { Series = "IR0021", SubSeries = "IR0021", Sku = "IR0021-1-2L", Size = "2L", Color = "黑", SellingPrice = 999, Stock = 0, PreStock = 0, Weight = 1, CreatedDate = DateTime.Now, ModifyDate = DateTime.Now, Enable = true });

            _context.SaveChanges();
        }

        [Fact]
        public async Task ProductFeature_CreateProduct_ShouldReturns_Instance()
        {
            var createProductCommand = new CreateProductCommand.CreateProductCommand()
            {
                ProductSeries = new CreateProductCommand.CreateProductSeriesDto()
                {
                    SeriesNo = "XX1234",
                    Name = "0000000000000000000",
                    Description = "XXXXXXXX",
                    OverseasDelivery = false,
                    Brand = string.Empty,
                    Material = string.Empty,
                    Origin = "Taiwan",
                    Accessories = string.Empty,
                    Attention = string.Empty,
                    Color = string.Empty,
                    Items = new List<CreateProductCommand.CreateProductItemDto>()
                    {
                        new CreateProductCommand.CreateProductItemDto()
                        {
                            Series = "XX1234",
                            SubSeries= "XX1234",
                            Sku = "XX1234-1-1",
                            Size = "S",
                            Color = "W",
                            SellingPrice = 999,
                            Stock = 10,
                            Weight = (decimal)0.2
                        }
                    }
                }
            };

            var response = await _mediator.Send(createProductCommand);

            var expectedSeries = await _context.ProductSeries.SingleOrDefaultAsync(p => p.Series == "XX1234");

            Assert.NotNull(expectedSeries);

            foreach (var item in createProductCommand.ProductSeries.Items)
            {
                var expectedSku = await _context.ProductSkus.SingleOrDefaultAsync(p => p.Sku == item.Sku);

                Assert.NotNull(expectedSku);
                Assert.Equal(expected: expectedSku.SubSeries, actual: item.SubSeries);
                Assert.Equal(expectedSku.SubSeries, item.SubSeries);
            }
        }

        [Fact]
        public async Task ProductFeature_GetProductById_ShouldReturns_ProductSeries()
        {
            var series = await _mediator.Send(new GetProductByIdQuery.GetProductByIdQuery() { SeriesNo = "IR0021" });

            Assert.NotNull(series);
            Assert.True(series.Items.Any());
        }

    }
}
