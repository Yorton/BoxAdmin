using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_14
{
    public class GetQuestion14Response
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
        /// 低腰
        /// </summary>
        [SwaggerParameter(Description = "低腰")]
        public LowRise LowRise { get; set; }

        /// <summary>
        /// 中腰
        /// </summary>
        [SwaggerParameter(Description = "中腰")]
        public MidRise MidRise { get; set; }

        /// <summary>
        /// 高腰
        /// </summary>
        [SwaggerParameter(Description = "高腰")]
        public HighRise HighRise { get; set; }
    }

    public class LowRise
    {
        /// <summary>
        /// 低腰-英文
        /// </summary>
        [SwaggerParameter(Description = "低腰-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 低腰-中文
        /// </summary>
        [SwaggerParameter(Description = "低腰-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantTopOption> Options { get; set; } = new List<PantTopOption>();
    }

    public class MidRise
    {
        /// <summary>
        /// 中腰-英文
        /// </summary>
        [SwaggerParameter(Description = "中腰-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 中腰-中文
        /// </summary>
        [SwaggerParameter(Description = "中腰-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantTopOption> Options { get; set; } = new List<PantTopOption>();
    }

    public class HighRise
    {
        /// <summary>
        /// 高腰-英文
        /// </summary>
        [SwaggerParameter(Description = "高腰-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 高腰-中文
        /// </summary>
        [SwaggerParameter(Description = "高腰-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantTopOption> Options { get; set; } = new List<PantTopOption>();
    }

    public class PantTopOption
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
