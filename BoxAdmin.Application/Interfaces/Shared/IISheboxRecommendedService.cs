using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Interfaces.Shared
{
    using BoxAdmin.Application.DTOs.Infrastructure.Shared;

    public interface IISheboxRecommendedService
    {
        Task<ISheboxRecommendedResponse> GetRecommendedProductItemsAsync(ISheboxRecommendedGetItemRequest request);
    }
}
