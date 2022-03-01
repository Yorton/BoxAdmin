using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBookById
{
    public class GetStyleBookByIdResponse
    {
        [SwaggerSchema("StyleBookId")]
        public Guid Id { get; set; }
        [SwaggerSchema("0 Disable 1 Enable")]
        public int State { get; set; }
        [SwaggerSchema("搭配組合圖片")]
        public string ImageUrl { get; set; }
        [SwaggerSchema("風格ID")]
        public Guid StyleId { get; set; }
        [SwaggerSchema("場景ID")]
        public Guid OccasionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
        [SwaggerSchema("搭配商品明細")]
        public List<StyleBookProduct> Items { get; set; } = new List<StyleBookProduct>();
        [SwaggerSchema("搭配師資料")]
        public Matchmaker Matchmaker { get; set; }
    }

    [SwaggerSchema("搭配商品明細")]
    public class StyleBookProduct 
    {
        public Guid StyleBookId { get; set; }
        [SwaggerSchema("系列編號")]
        public string Series { get; set; }
        [SwaggerSchema("顏色")]
        public string Color { get; set; }
        [SwaggerSchema("圖片Url")]
        public string ImageUrl { get; set; }
        [SwaggerSchema("分類名稱")]
        public string CatelogName { get; set; }
    }

    [SwaggerSchema("搭配師資料")]
    public class Matchmaker
    {
        [SwaggerSchema("搭配師ID")]
        public Guid Id { get; set; }
        [SwaggerSchema("搭配師名稱")]
        public string Name { get; set; }
    }
}
