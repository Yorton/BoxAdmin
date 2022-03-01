using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductByScore
{
    /// <summary>
    /// 猜你喜歡
    /// </summary>
    public class GetProductByScoreResponse
    {
        /// <summary>
        /// 會員ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 商品列表
        /// </summary>
        public List<ProductItem> Items { get; set; } = new List<ProductItem>();
    }
}
