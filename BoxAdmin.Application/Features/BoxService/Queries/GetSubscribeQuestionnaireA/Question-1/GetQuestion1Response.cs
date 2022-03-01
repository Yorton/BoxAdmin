using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_1
{
    public class GetQuestion1Response
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
        /// 問題
        /// </summary>
        [SwaggerParameter(Description = "問題")]
        public List<Question> Questions { get; set; } = new List<Question>();
    }

    public class Question 
    {
        /// <summary>
        /// 選項編號
        /// </summary>
        [SwaggerParameter(Description = "選項編號")]
        public string No { get; set; }

        /// <summary>
        /// 選項名稱
        /// </summary>
        [SwaggerParameter(Description = "選項名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<StyleOption> Options { get; set; } = new List<StyleOption>();
    }

    public class StyleOption
    {
        /// <summary>
        /// 選項值(1 = (Dislike) 不喜歡, 3 = (Normal) 普通, 5= (Like) 喜歡)
        /// </summary>
        [SwaggerParameter(Description = "選項值")]
        public string Value { get; set; }

        /// <summary>
        /// 選項名稱-英文
        /// </summary>
        [SwaggerParameter(Description = "選項名稱-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 選項名稱-中文
        /// </summary>
        [SwaggerParameter(Description = "選項名稱-中文")]
        public string ChiName { get; set; }
    }


}
