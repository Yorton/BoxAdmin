using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductByRecommand
{
    /// <summary>
    /// 系統推薦清單
    /// </summary>
    public class GetProductByRecommandResponse
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<ProductItem> Items { get; set; } = new List<ProductItem>();
    }
}
