using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxSurveyAnswer
{
    public class GetBoxSurveyAnswerResponse
    {
        /// <summary>
        /// 題目號
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// 題目項
        /// </summary>
        public string NoName { get; set; }

        /// <summary>
        /// 子題目項
        /// </summary>
        public string SubNoName { get; set; }

        /// <summary>
        /// 答案
        /// </summary>
        public string Answer { get; set; }
    }
       
    public class LikeLevel
    {
        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "1")]
        public string Item1 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "2")]
        public string Item2 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "3")]
        public string Item3 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "4")]
        public string Item4 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "5")]
        public string Item5 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "6")]
        public string Item6 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "7")]
        public string Item7 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "8")]
        public string Item8 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "9")]
        public string Item9 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "10")]
        public string Item10 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "11")]
        public string Item11 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "12")]
        public string Item12 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "13")]
        public string Item13 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "14")]
        public string Item14 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "15")]
        public string Item15 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "16")]
        public string Item16 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "17")]
        public string Item17 { get; set; }

        /// <summary>
        /// 選項(1:不喜歡 3:普通 5:喜歡)
        /// </summary>
        [JsonProperty(PropertyName = "18")]
        public string Item18 { get; set; }
    }

    public class BodySize 
    {
        /// <summary>
        /// 身高
        /// </summary>
        [JsonProperty(PropertyName = "Height")]
        public int Height { get; set; }

        /// <summary>
        /// 體重
        /// </summary>
        [JsonProperty(PropertyName = "Weigh")]
        public int Weigh { get; set; }

        /// <summary>
        /// 肩寬
        /// </summary>
        [JsonProperty(PropertyName = "ShoulderWidth")]
        public int ShoulderWidth { get; set; }

        /// <summary>
        /// 胸圍
        /// </summary>
        [JsonProperty(PropertyName = "Bust")]
        public int Bust { get; set; }

        /// <summary>
        /// 腰圍
        /// </summary>
        [JsonProperty(PropertyName = "WaistCircumference")]
        public int WaistCircumference { get; set; }

        /// <summary>
        /// 臀圍
        /// </summary>
        [JsonProperty(PropertyName = "HipCircumference")]
        public int HipCircumference { get; set; }

        /// <summary>
        /// 大腿圍
        /// </summary>
        [JsonProperty(PropertyName = "ThighCircumference")]
        public int ThighCircumference { get; set; }
    }

    public class ClothesSize
    {
        /// <summary>
        /// 上衣
        /// </summary>
        [JsonProperty(PropertyName = "TopClothes")]
        public List<string> TopClothes { get; set; } = new List<string>();

        /// <summary>
        /// 下著
        /// </summary>
        [JsonProperty(PropertyName = "Bottoms")]
        public List<string> Bottoms { get; set; } = new List<string>();

        /// <summary>
        /// 牛仔褲
        /// </summary>
        [JsonProperty(PropertyName = "Jeans")]
        public List<string> Jeans { get; set; } = new List<string>();

        /// <summary>
        /// 洋裝
        /// </summary>
        [JsonProperty(PropertyName = "Dress")]
        public List<string> Dress { get; set; } = new List<string>();

        /// <summary>
        /// 內衣
        /// </summary>
        [JsonProperty(PropertyName = "Brassier")]
        public Brassier Brassier { get; set; } = new Brassier();
    }

    public class Brassier 
    {
        /// <summary>
        /// 罩杯
        /// </summary>
        [JsonProperty(PropertyName = "Bra")]
        public string Bra { get; set; }

        /// <summary>
        /// 尺碼
        /// </summary>
        [JsonProperty(PropertyName = "Size")]
        public List<string> Size { get; set; } = new List<string>();
    }

    public class BodyShape 
    {
        /// <summary>
        /// 肩膀
        /// </summary>
        [JsonProperty(PropertyName = "Shoulder")]
        public string Shoulder { get; set; }

        /// <summary>
        /// 臉部
        /// </summary>
        [JsonProperty(PropertyName = "Face")]
        public string Face { get; set; }

        /// <summary>
        /// 手臂
        /// </summary>
        [JsonProperty(PropertyName = "Arm")]
        public string Arm { get; set; }

        /// <summary>
        /// 脖子
        /// </summary>
        [JsonProperty(PropertyName = "Neck")]
        public string Neck { get; set; }

        /// <summary>
        /// 背部
        /// </summary>
        [JsonProperty(PropertyName = "Back")]
        public string Back { get; set; }

        /// <summary>
        /// 胸部
        /// </summary>
        [JsonProperty(PropertyName = "Chest")]
        public string Chest { get; set; }

        /// <summary>
        /// 腰部
        /// </summary>
        [JsonProperty(PropertyName = "Loins")]
        public string Loins { get; set; }

        /// <summary>
        /// 腹部
        /// </summary>
        [JsonProperty(PropertyName = "Belly")]
        public string Belly { get; set; }

        /// <summary>
        /// 臀部
        /// </summary>
        [JsonProperty(PropertyName = "Hip")]
        public string Hip { get; set; }

        /// <summary>
        /// 髖部
        /// </summary>
        [JsonProperty(PropertyName = "HipBone")]
        public string HipBone { get; set; }

        /// <summary>
        /// 腿
        /// </summary>
        [JsonProperty(PropertyName = "Leg")]
        public string Leg { get; set; }

        /// <summary>
        /// 大腿
        /// </summary>
        [JsonProperty(PropertyName = "Thigh")]
        public string Thigh { get; set; }

        /// <summary>
        /// 小腿
        /// </summary>
        [JsonProperty(PropertyName = "Shank")]
        public string Shank { get; set; }
    }

    public class Gerneric1 
    {
        #region PantFit
        /// <summary>
        /// 緊身
        /// </summary>
        [JsonProperty(PropertyName = "SkinnyFit")]
        public int SkinnyFit { get; set; }

        /// <summary>
        /// 合身
        /// </summary>
        [JsonProperty(PropertyName = "Fit")]
        public int Fit { get; set; }

        /// <summary>
        /// 寬版
        /// </summary>
        [JsonProperty(PropertyName = "Culottes")]
        public int Culottes { get; set; }
        #endregion

        #region PantLength
        /// <summary>
        /// 短褲
        /// </summary>
        [JsonProperty(PropertyName = "ShortPants")]
        public int ShortPants { get; set; }

        /// <summary>
        /// 五分褲
        /// </summary>
        [JsonProperty(PropertyName = "Shorts")]
        public int Shorts { get; set; }

        /// <summary>
        /// 七分褲
        /// </summary>
        [JsonProperty(PropertyName = "CalfLengthPants")]
        public int CalfLengthPants { get; set; }

        /// <summary>
        /// 九分褲
        /// </summary>
        [JsonProperty(PropertyName = "AnkleLengthPants")]
        public int AnkleLengthPants { get; set; }

        /// <summary>
        /// 落地褲
        /// </summary>
        [JsonProperty(PropertyName = "FloorPants")]
        public int FloorPants { get; set; }
        #endregion

        #region PantTop
        /// <summary>
        /// 低腰
        /// </summary>
        [JsonProperty(PropertyName = "LowRise")]
        public int LowRise { get; set; }

        /// <summary>
        /// 中腰
        /// </summary>
        [JsonProperty(PropertyName = "MidRise")]
        public int MidRise { get; set; }

        /// <summary>
        /// 高腰
        /// </summary>
        [JsonProperty(PropertyName = "HighRise")]
        public int HighRise { get; set; }
        #endregion

        #region ClothesPrice
        /// <summary>
        /// 上衣(價位)
        /// </summary>
        [JsonProperty(PropertyName = "TopClothes")]
        public int TopClothes { get; set; }

        /// <summary>
        /// 下身(價位)
        /// </summary>
        [JsonProperty(PropertyName = "Bottoms")]
        public int Bottoms { get; set; }

        /// <summary>
        /// 洋裝(價位)
        /// </summary>
        [JsonProperty(PropertyName = "Dress")]
        public int Dress { get; set; }

        /// <summary>
        /// 外套(價位)
        /// </summary>
        [JsonProperty(PropertyName = "Outerwear")]
        public int Outerwear { get; set; }

        /// <summary>
        /// 飾品(價位)
        /// </summary>
        [JsonProperty(PropertyName = "Accessory")]
        public int Accessory { get; set; }
        #endregion

        #region ProductSatisfaction
        /// <summary>
        /// 產品期待
        /// </summary>
        [JsonProperty(PropertyName = "ProductExpect")]
        public int ProductExpect { get; set; }

        /// <summary>
        /// 服務滿意度
        /// </summary>
        [JsonProperty(PropertyName = "ServiceSatisfaction")]
        public int ServiceSatisfaction { get; set; }

        /// <summary>
        /// 搭配師穿搭組合
        /// </summary>
        [JsonProperty(PropertyName = "ConsultantStyle")]
        public int ConsultantStyle { get; set; }
        #endregion
    }

    public class PantFit : Gerneric1
    {
    }

    public class PantLength : Gerneric1
    {
    }

    public class PantTop : Gerneric1
    {
    }

    public class ClothesPrice : Gerneric1
    {
    }

    public class ProductSatisfaction : Gerneric1
    {
    }


    public class Gerneric2 
    {
        #region iSheboxExperience

        /// <summary>
        /// 體驗說明
        /// </summary>
        [JsonProperty(PropertyName = "Experience")]
        public int Experience { get; set; }

        /// <summary>
        /// 其他說明
        /// </summary>
        [JsonProperty(PropertyName = "Other")]
        public string Other { get; set; }
        #endregion

        #region Job

        /// <summary>
        /// 產業
        /// </summary>
        [JsonProperty(PropertyName = "Industry")]
        public string Industry { get; set; }

        /// <summary>
        /// 其他產業說明
        /// </summary>
        [JsonProperty(PropertyName = "IndustryOther")]
        public string IndustryOther { get; set; }

        /// <summary>
        /// 職能
        /// </summary>
        [JsonProperty(PropertyName = "Competency")]
        public string Competency { get; set; }

        /// <summary>
        /// 其他職能說明
        /// </summary>
        [JsonProperty(PropertyName = "CompetencyOther")]
        public string CompetencyOther { get; set; }

        /// <summary>
        /// 管理職
        /// </summary>
        [JsonProperty(PropertyName = "Management")]
        public bool Management { get; set; }
        #endregion

        #region ClothesSuitable
        /// <summary>
        /// 整體感覺程度
        /// </summary>
        [JsonProperty(PropertyName = "OverAll")]
        public int OverAll { get; set; }
        #endregion
    }

    public class iSheboxExperience : Gerneric2
    {
    }

    public class Job : Gerneric2
    {
    }

    public class ClothesSuitable : Gerneric2
    {
    }

    public class Occasion
    {
        /// <summary>
        /// 需求場合A
        /// </summary>
        [JsonProperty(PropertyName = "OptionA")]
        public int? OptionA { get; set; }

        /// <summary>
        /// 需求場合B
        /// </summary>
        [JsonProperty(PropertyName = "OptionB")]
        public int? OptionB { get; set; }

        /// <summary>
        /// 需求場合C
        /// </summary>
        [JsonProperty(PropertyName = "OptionC")]
        public int? OptionC { get; set; }

        /// <summary>
        /// 其他說明
        /// </summary>
        [JsonProperty(PropertyName = "Other")]
        public string Other { get; set; }
    }

    public class BoxItems
    {
        /// <summary>
        /// 特別想收到的單品
        /// </summary>
        public List<int> Desired { get; set; } = new List<int>();

        /// <summary>
        /// 不想收到的單品
        /// </summary>
        public List<int> Undesired { get; set; } = new List<int>();

    }
}
