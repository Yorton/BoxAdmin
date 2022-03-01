using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_13
{
    public class GetQuestion13Response
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
        /// 短褲
        /// </summary>
        [SwaggerParameter(Description = "短褲")]
        public ShortPants ShortPants { get; set; }

        /// <summary>
        /// 五分褲
        /// </summary>
        [SwaggerParameter(Description = "五分褲")]
        public Shorts Shorts { get; set; }

        /// <summary>
        /// 七分褲
        /// </summary>
        [SwaggerParameter(Description = "七分褲")]
        public CalfLengthPants CalfLengthPants { get; set; }

        /// <summary>
        /// 九分褲
        /// </summary>
        [SwaggerParameter(Description = "九分褲")]
        public AnkleLengthPants AnkleLengthPants { get; set; }

        /// <summary>
        /// 落地褲
        /// </summary>
        [SwaggerParameter(Description = "落地褲")]
        public FloorPants FloorPants { get; set; }
    }

    public class ShortPants
    {
        /// <summary>
        /// 短褲-英文
        /// </summary>
        [SwaggerParameter(Description = "短褲-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 短褲-中文
        /// </summary>
        [SwaggerParameter(Description = "短褲-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantLengthOption> Options { get; set; } = new List<PantLengthOption>();
    }

    public class Shorts
    {
        /// <summary>
        /// 五分褲-英文
        /// </summary>
        [SwaggerParameter(Description = "五分褲-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 五分褲-中文
        /// </summary>
        [SwaggerParameter(Description = "五分褲-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantLengthOption> Options { get; set; } = new List<PantLengthOption>();
    }

    public class CalfLengthPants
    {
        /// <summary>
        /// 七分褲-英文
        /// </summary>
        [SwaggerParameter(Description = "七分褲-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 七分褲-中文
        /// </summary>
        [SwaggerParameter(Description = "七分褲-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantLengthOption> Options { get; set; } = new List<PantLengthOption>();
    }

    public class AnkleLengthPants
    {
        /// <summary>
        /// 九分褲-英文
        /// </summary>
        [SwaggerParameter(Description = "九分褲-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 九分褲-中文
        /// </summary>
        [SwaggerParameter(Description = "九分褲-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantLengthOption> Options { get; set; } = new List<PantLengthOption>();
    }

    public class FloorPants
    {
        /// <summary>
        /// 落地褲-英文
        /// </summary>
        [SwaggerParameter(Description = "落地褲-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 落地褲-中文
        /// </summary>
        [SwaggerParameter(Description = "落地褲-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantLengthOption> Options { get; set; } = new List<PantLengthOption>();
    }

    public class PantLengthOption
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
