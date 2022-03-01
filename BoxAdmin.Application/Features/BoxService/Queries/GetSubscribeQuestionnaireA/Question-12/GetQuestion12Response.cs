using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_12
{
    public class GetQuestion12Response
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
        /// 緊身
        /// </summary>
        [SwaggerParameter(Description = "緊身")]
        public SkinnyFit SkinnyFit { get; set; }

        /// <summary>
        /// 合身
        /// </summary>
        [SwaggerParameter(Description = "合身")]
        public Fit Fit { get; set; }

        /// <summary>
        /// 寬版
        /// </summary>
        [SwaggerParameter(Description = "寬版")]
        public Culottes Culottes { get; set; }

    }

    public class SkinnyFit 
    {
        /// <summary>
        /// 緊身-英文
        /// </summary>
        [SwaggerParameter(Description = "緊身-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 緊身-中文
        /// </summary>
        [SwaggerParameter(Description = "緊身-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantStyleOption> Options { get; set; } = new List<PantStyleOption>();
    }

    public class Fit
    {
        /// <summary>
        /// 合身-英文
        /// </summary>
        [SwaggerParameter(Description = "合身-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 合身-中文
        /// </summary>
        [SwaggerParameter(Description = "合身-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantStyleOption> Options { get; set; } = new List<PantStyleOption>();
    }

    public class Culottes
    {
        /// <summary>
        /// 寬版-英文
        /// </summary>
        [SwaggerParameter(Description = "寬版-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 寬版-中文
        /// </summary>
        [SwaggerParameter(Description = "寬版-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<PantStyleOption> Options { get; set; } = new List<PantStyleOption>();
    }

    public class PantStyleOption 
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
