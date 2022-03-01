using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_7
{
    public class GetQuestion7Response
    {
        /// <summary>
        /// 隸屬階層名稱(Style-風格, Body Shape-身形, Preference-偏好, Habit-習慣, Personal-個人)
        /// </summary>
        [SwaggerParameter(Description = "隸屬階層名稱")]
        public string LevelType { get; set; }

        /// <summary>
        /// 題目名稱
        /// </summary>
        [SwaggerParameter(Description = "題目名稱")]
        public string QuestionName { get; set; }

        /// <summary>
        /// 上衣
        /// </summary>
        [SwaggerParameter(Description = "上衣")]
        public TopClothes TopClothes { get; set; }

        /// <summary>
        /// 下著
        /// </summary>
        [SwaggerParameter(Description = "下著")]
        public Bottoms Bottoms { get; set; }

        /// <summary>
        /// 牛仔褲
        /// </summary>
        [SwaggerParameter(Description = "牛仔褲")]
        public Jeans Jeans { get; set; }

        /// <summary>
        /// 洋裝
        /// </summary>
        [SwaggerParameter(Description = "洋裝")]
        public Dress Dress { get; set; }

        /// <summary>
        /// 內衣
        /// </summary>
        [SwaggerParameter(Description = "內衣")]
        public Brassier Brassier { get; set; }

    }

    

    public class TopClothes 
    {
        /// <summary>
        /// 上衣尺碼-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "上衣尺碼-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 上衣尺碼-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "上衣尺碼-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 上衣尺碼選項
        /// </summary>
        [SwaggerParameter(Description = "上衣尺碼選項")]
        public List<string> Options { get; set; } = new List<string>();
    }

    public class Bottoms
    {
        /// <summary>
        /// 下著尺碼-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "下著尺碼-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 下著尺碼-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "下著尺碼-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 下著尺碼選項
        /// </summary>
        [SwaggerParameter(Description = "下著尺碼選項")]
        public List<string> Options { get; set; } = new List<string>();
    }

    public class Jeans
    {
        /// <summary>
        /// 牛仔褲尺碼-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "牛仔褲尺碼-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 牛仔褲尺碼-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "牛仔褲尺碼-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 牛仔褲尺碼選項
        /// </summary>
        [SwaggerParameter(Description = "牛仔褲尺碼選項")]
        public List<string> Options { get; set; } = new List<string>();
    }

    public class Dress
    {
        /// <summary>
        /// 洋裝尺碼-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "洋裝尺碼-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 洋裝尺碼-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "洋裝尺碼-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 洋裝尺碼選項
        /// </summary>
        [SwaggerParameter(Description = "洋裝尺碼選項")]
        public List<string> Options { get; set; } = new List<string>();
    }

    public class Brassier 
    {
        /// <summary>
        /// 內衣尺碼-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "內衣尺碼-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 內衣尺碼-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "內衣尺碼-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 罩杯尺碼選項
        /// </summary>
        [SwaggerParameter(Description = "罩杯尺碼選項")]
        public List<string> BraOptions { get; set; } = new List<string>();

        /// <summary>
        /// 內衣尺碼選項
        /// </summary>
        [SwaggerParameter(Description = "內衣尺碼選項")]
        public List<string> SizeOptions { get; set; } = new List<string>();
    }
}
