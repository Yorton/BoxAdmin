using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_17
{
    public class GetQuestion17Response
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
        public TopClothesPrice TopClothes { get; set; }

        /// <summary>
        /// 下身
        /// </summary>
        [SwaggerParameter(Description = "下身")]
        public BottomsPrice Bottoms { get; set; }

        /// <summary>
        /// 洋裝
        /// </summary>
        [SwaggerParameter(Description = "洋裝")]
        public DressPrice Dress { get; set; }

        /// <summary>
        /// 外套
        /// </summary>
        [SwaggerParameter(Description = "外套")]
        public OuterwearPrice Outerwear { get; set; }

        /// <summary>
        /// 飾品
        /// </summary>
        [SwaggerParameter(Description = "飾品")]
        public AccessoryPrice Accessory { get; set; }
    }

    public class TopClothesPrice
    {
        /// <summary>
        /// 上衣-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "上衣-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 上衣-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "上衣-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 上衣價位區間選項
        /// </summary>
        [SwaggerParameter(Description = "上衣價位區間選項")]
        public List<PriceOption> Options { get; set; } = new List<PriceOption>();
    }

    public class BottomsPrice
    {
        /// <summary>
        /// 下身-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "下身-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 下身-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "下身-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 下身價位區間選項
        /// </summary>
        [SwaggerParameter(Description = "下身價位區間選項")]
        public List<PriceOption> Options { get; set; } = new List<PriceOption>();
    }

    public class DressPrice
    {
        /// <summary>
        /// 洋裝-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "洋裝-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 洋裝-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "洋裝-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 洋裝價位區間選項
        /// </summary>
        [SwaggerParameter(Description = "洋裝價位區間選項")]
        public List<PriceOption> Options { get; set; } = new List<PriceOption>();
    }

    public class OuterwearPrice
    {
        /// <summary>
        /// 外套-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "外套-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 外套-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "外套-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 外套價位區間選項
        /// </summary>
        [SwaggerParameter(Description = "外套價位區間選項")]
        public List<PriceOption> Options { get; set; } = new List<PriceOption>();
    }

    public class AccessoryPrice
    {
        /// <summary>
        /// 飾品-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "飾品-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 飾品-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "飾品-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 飾品價位區間選項
        /// </summary>
        [SwaggerParameter(Description = "飾品價位區間選項")]
        public List<PriceOption> Options { get; set; } = new List<PriceOption>();
    }

    public class PriceOption
    {
        /// <summary>
        /// 選項名稱
        /// </summary>
        [SwaggerParameter(Description = "選項名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 選項值
        /// </summary>
        [SwaggerParameter(Description = "選項值")]
        public string Value { get; set; }
    }
}
