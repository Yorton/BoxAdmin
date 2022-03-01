using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBooks
{
    public class GetStyleBooksResponse
    {
        [SwaggerSchema("搭配商品")]
        public List<StyleBookListItem> Items { get; set; }

        [SwaggerSchema("風格總數")]
        public List<StyleCount> StyleCounts { get; set; }

        public GetStyleBooksResponse() : this(new List<StyleBookListItem>(), new List<StyleCount>()) { }
        public GetStyleBooksResponse(List<StyleBookListItem> items, List<StyleCount> styleCounts)
        {
            Items = items;
            StyleCounts = styleCounts;
        }
    }

    [SwaggerSchema("搭配商品")]
    public class StyleBookListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MatchmakerInfoId { get; set; }
        public Guid StyleId { get; set; }
        public Guid OccasionId { get; set; }
        public int State { get; set; }
        public string Matchmaker { get; set; }
        public string Style { get; set; }
        public string Occasion { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
        public List<string> ColorImage { get; set; }
    }

    [SwaggerSchema("風格總數")]
    public class StyleCount
    { 
        public Guid StyleId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
