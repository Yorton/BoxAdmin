using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BoxAdmin.Application.DTOs.Infrastructure.Shared
{
    public class ISheboxRecommendedBaseRequest
    {
        [JsonPropertyName("token")] public string Token { get; set; }
        [JsonPropertyName("ven_guid")] public string VenGuid { get; set; }
        [JsonPropertyName("ven_session")] public string VenSession { get; set; }
        [JsonPropertyName("uid")] public string Uid { get; set; }
        public ISheboxRecommendedBaseRequest()
        {
            this.Token = "xVt5WNBb8r";
            this.VenGuid = "test_ven_guid";
            this.VenSession = "test_ven_session";
            this.Uid = "test_uid";
        }
    }

    public class ISheboxRecommendedGetItemRequest : ISheboxRecommendedBaseRequest
    {
        [JsonPropertyName("rec_pos")] public string RecPos { get; set; }
        [JsonPropertyName("rec_type")] public string RecType { get; set; }
        [JsonPropertyName("gid")] public string GoodsId { get; set; }
        [JsonPropertyName("topk")] public int TopK { get; set; }
        [JsonPropertyName("excluded_ids")] public List<string> ExcludedIds { get; set; }
        [JsonPropertyName("rescore_tag_list")] public List<RescoreTag> RescoreTagList { get; set; }
        public ISheboxRecommendedGetItemRequest() : base()
        {
            this.RecPos = "back_match";
            this.RecType = "GetItems";
            this.GoodsId = "KS0704";
            this.ExcludedIds = new List<string>() { "excluded_gid_1", "excluded_gid_2" };
            this.RescoreTagList = new List<RescoreTag>() 
            {
                new RescoreTag() { Field = "occasion_id", Value = "A1234", Score = 1000 }
            };
            this.TopK = 60;
        }

        public class RescoreTag
        {
            [JsonPropertyName("field")] public string Field { get; set; }
            [JsonPropertyName("value")] public string Value { get; set; }
            [JsonPropertyName("score")] public int Score { get; set; }

        }
    }
}
