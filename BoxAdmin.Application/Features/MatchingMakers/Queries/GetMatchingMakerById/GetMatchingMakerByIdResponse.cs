using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.MatchingMakers.Queries.GetMatchingMakerById
{
    public class GetMatchingMakerByIdResponse
    {
        public Guid Id { get; set; }
        [SwaggerSchema("名稱")] public string Name { get; set; }
        [SwaggerSchema("照片URL")] public List<string> PictureUrl { get; set; }
        [SwaggerSchema("簽名檔URL")] public List<string> SignatureUrl { get; set; }
        [SwaggerSchema("自介")] public string SelfIntroduction { get; set; }
        [SwaggerSchema("口號")] public string Slogan { get; set; }
        [SwaggerSchema("擅長風格")] public string LikeStyle { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
        [SwaggerSchema("風格搭配盒數")] public List<GetMatchingMakerById_MatchingCount> MatchingCounts { get; set; } = new List<GetMatchingMakerById_MatchingCount>();
    }

    public class GetMatchingMakerById_MatchingCount
    {
        [SwaggerSchema("StyleId")] public Guid StyleId { get; set; }
        [SwaggerSchema("風格")] public string Title { get; set; }
        public int Count { get; set; }
    }
}
