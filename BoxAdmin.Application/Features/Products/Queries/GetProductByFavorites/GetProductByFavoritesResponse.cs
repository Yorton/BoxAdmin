using System;
using System.Collections.Generic;

namespace BoxAdmin.Application.Features.Products.Queries.GetProductByFavorites
{
    /// <summary>
    /// 收藏清單
    /// </summary>
    public class GetProductByFavoritesResponse
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
