using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_6
{
    public class GetQuestion6Response
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
        /// 身形尺寸
        /// </summary>
        [SwaggerParameter(Description = "身形尺寸")]
        public List<BodySizeName> BodySizeNameList { get; set; } = new List<BodySizeName>();
    }

    public class BodySizeName 
    {
        /// <summary>
        /// 身形尺寸-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "身形尺寸-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 身形尺寸-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "身形尺寸-英文名稱")]
        public string EnName { get; set; }
    }
}
