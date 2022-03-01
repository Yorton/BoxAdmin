using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_11
{
    public class GetQuestion11Response
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
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<DressUpOption> Options { get; set; } = new List<DressUpOption>();
    }

    public class DressUpOption
    {
        /// <summary>
        /// 選項值
        /// </summary>
        [SwaggerParameter(Description = "選項值")]
        public string Value { get; set; }

        /// <summary>
        /// 選項名稱
        /// </summary>
        [SwaggerParameter(Description = "選項名稱")]
        public string Name { get; set; }
    }
}
