using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MediatR;

namespace BoxAdmin.Application.Test
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using Microsoft.Extensions.DependencyInjection;
    using CreateProductQueries = BoxAdmin.Application.Features.Customers.Queries;

    public class CustomerTests
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;


        public CustomerTests(IMediator mediator, IBoxDbContext context, IServiceProvider serviceProvider)
        {
            _mediator = mediator;

            _serviceProvider = serviceProvider;

            context.CustomerInfos.Add(new Domain.Entities.BoxContext.CustomerInfo()
            {
                CustomerId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
            });

            context.SaveChanges();
        }

        [Fact]
        public async Task CustomerFeature_GetCustomerById_ShouldReturns_Instance()
        {
            var request = new CreateProductQueries.GetCustomerById.GetCustomerByIdQuery()
            {
                Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
            };

            var customerResponse = await _mediator.Send(request);

            Assert.Equal<Guid>(request.Id, customerResponse.Id);
        }
    }
}
