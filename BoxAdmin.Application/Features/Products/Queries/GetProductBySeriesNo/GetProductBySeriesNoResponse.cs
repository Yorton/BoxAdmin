using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductBySeriesNo
{
    public class GetProductBySeriesNoResponse
    {
        [SwaggerSchema("款號")] public string SeriesNo { get; set; }
        [SwaggerSchema("商品SKU")] public List<ProductItem> Items { get; set; } = new List<ProductItem>();
    }
}
