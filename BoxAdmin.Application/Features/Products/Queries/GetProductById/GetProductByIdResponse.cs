using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdResponse
    {
        [SwaggerSchema("主要系列編號")] public string Series { get; set; }
        [SwaggerSchema("系列名稱")] public string Name { get; set; }
        [SwaggerSchema("商品描述")] public string Description { get; set; }
        [SwaggerSchema("單價區間(小)")] public int PriceMin { get; set; }
        [SwaggerSchema("單價區間(大)")] public int PriceMax { get; set; }
        [SwaggerSchema("海外配送")] public bool OverseasDeliverya { get; set; }
        [SwaggerSchema("品牌布標")] public string Brand { get; set; }
        [SwaggerSchema("首次上架")] public DateTime? FirstSellDate { get; set; }
        [SwaggerSchema("詳情 材質")] public string Material { get; set; }
        [SwaggerSchema("詳情 產地")] public string Origin { get; set; }
        [SwaggerSchema("詳情 色系")] public string Color { get; set; }
        [SwaggerSchema("詳情 配件")] public string Accessories { get; set; }
        [SwaggerSchema("注意事項")] public string Attention { get; set; }
        [SwaggerSchema("啟用")] public string Enable { get; set; }
        [SwaggerSchema("商品SKU")] public List<GetProductById_ProductSkuItem> Items { get; set; } = new List<GetProductById_ProductSkuItem>();
        [SwaggerSchema("商品分色圖")] public List<GetProductById_ProductColorImage> ColorImages { get; set; } = new List<GetProductById_ProductColorImage>();
    }

    // 商品SKU
    public class GetProductById_ProductSkuItem
    {
        [SwaggerSchema("主系列編號")] public string Series { get; set; }
        [SwaggerSchema("子系列編號")] public string SubSeries { get; set; }
        [SwaggerSchema("產品編號")] public string SKU { get; set; }
        [SwaggerSchema("尺寸")] public string Size { get; set; }
        [SwaggerSchema("顏色")] public string Color { get; set; }
        [SwaggerSchema("單價")] public int SellingPrice { get; set; }
        [SwaggerSchema("庫存")] public int Stock { get; set; }
        [SwaggerSchema("預購庫存")] public int PreStock { get; set; }
        [SwaggerSchema("重量")] public decimal Weight { get; set; }
        [SwaggerSchema("啟用")] public bool Enable { get; set; }
    }

    public class GetProductById_ProductColorImage
    {
        [SwaggerSchema("系列編號")] public string Series { get; set; }
        [SwaggerSchema("顏色")] public string Color { get; set; }
        [SwaggerSchema("圖片路徑")] public string ImageUrl { get; set; }
    }
}
