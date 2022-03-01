using BoxAdmin.Application.Features.Products.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.StyleBooks.Queries.GetProductByTag
{
    public class GetProductByTagResponse
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        public List<ProductItem> Items { get; set; } = new List<ProductItem>();
    }
}
