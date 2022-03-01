using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.MatchingMakers.Queries.GetMatchingMakers
{
    public class GetMatchingMakersResponse
    {
        [SwaggerSchema("搭配師名單")]
        public List<MatchingMakerListItem> MatchingMakers { get; set; }
    }

    public class MatchingMakerListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [SwaggerSchema("照片")] public List<string> Pictures { get; set; }
        //[SwaggerSchema("簽名圖片")] public string SignatureUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        [SwaggerSchema("搭配盒數")] public int BoxCount { get; set; }
        [SwaggerSchema("風格搭配盒數")] public List<MatchingCount> MatchingCounts { get; set; }
    }

    public class MatchingCount
    {
        [SwaggerSchema("StyleId")] public Guid StyleId { get; set; }
        [SwaggerSchema("風格")] public string Title { get; set; }
        public int Count { get; set; }
    }
}
