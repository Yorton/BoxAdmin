
namespace BoxAdmin.Application.Features.Products.Queries
{
    public class ProductItem
    {
        /// <summary>
        /// 商品編號
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 系列編號
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// 商品圖(分色主圖)
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 商品名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商品價格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 商品顏色
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// 商品尺寸
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 商品重
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 庫存
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// 預購庫存
        /// </summary>
        public int PreStock { get; set; }
    }
}
