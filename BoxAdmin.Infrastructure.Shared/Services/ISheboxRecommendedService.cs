using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BoxAdmin.Infrastructure.Shared.Services
{
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Application.DTOs.Infrastructure.Shared;

    public class ISheboxRecommendedService : IISheboxRecommendedService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ISheboxRecommendedService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ISheboxRecommendedResponse> GetRecommendedProductItemsAsync(ISheboxRecommendedGetItemRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient("iSheboxRecommended");
            var json = JsonSerializer.Serialize(request);
            var contentPost = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync("hermes/api/goods/rank", contentPost);
            var responseJson = await response.Content.ReadAsStringAsync();
            var recommendedItemObject = JsonSerializer.Deserialize<ISheboxRecommendedResponse>(responseJson);

            return recommendedItemObject;
        }
    }
}
