using System;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Moq.Protected;

using BoxAdmin.Application.DTOs.Images;
using BoxAdmin.Infrastructure.Shared;
using BoxAdmin.Infrastructure.Shared.Services;

namespace BoxAdmin.Infrastructure.Test
{
    using Application.DTOs.Infrastructure.Shared;
    public class ISheboxRecommendedServiceTest
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ISheboxRecommendedServiceTest(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Fact]
        public async Task Test()
        {
            var service = new ISheboxRecommendedService(_httpClientFactory);
            await service.GetRecommendedProductItemsAsync(new ISheboxRecommendedGetItemRequest());
        }
    }
}
