using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BoxAdmin.Application.DTOs.Infrastructure.Shared
{
    public class ISheboxRecommendedResponse
    {
        [JsonPropertyName("recomd_id")] public string RecomdId { get; set; }
        [JsonPropertyName("took")] public double Took { get; set; }
        [JsonPropertyName("timed_out")] public bool TimedOut { get; set; }
        [JsonPropertyName("recomd_list")] public List<RecomdListItem> RecomdList { get; set; }

        public class RecomdListItem
        {
            [JsonPropertyName("id")] public string Id { get; set; }
            [JsonPropertyName("name")] public string Name { get; set; }
            [JsonPropertyName("score")] public double Score { get; set; }
            [JsonPropertyName("sale_price")] public double SalePrice { get; set; }
            [JsonPropertyName("category_code")] public string CategoryCode { get; set; }
            [JsonPropertyName("goods_page_url")] public string GoodsPageUrl { get; set; }
            [JsonPropertyName("goods_img_url")] public string GoodsImgUrl { get; set; }
            [JsonPropertyName("ref_item_list")] public List<RefListItem> RefItemList { get; set; }
            [JsonPropertyName("sales")] public string Sales { get; set; }
            [JsonPropertyName("group_category_code")] public string GroupCategoryCode { get; set; }
            [JsonPropertyName("msg_type")] public string MsgType { get; set; }
            [JsonPropertyName("msg")] public string Msg { get; set; }
            [JsonPropertyName("msg_score")] public double MsgScore { get; set; }
            public class RefListItem
            {
                [JsonPropertyName("item_name")] public string ItemName { get; set; }
                [JsonPropertyName("alg_name")] public string AlgName { get; set; }
                [JsonPropertyName("ref_model")] public string RefModel { get; set; }
                [JsonPropertyName("score")] public double Score { get; set; }
            }
        }
    }
}
