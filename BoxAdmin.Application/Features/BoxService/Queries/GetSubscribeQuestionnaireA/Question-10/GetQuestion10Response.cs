using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_10
{
    public class GetQuestion10Response
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
        /// 修飾部位
        /// </summary>
        [SwaggerParameter(Description = "修飾部位")]
        public List<BodyPart> BodyPartList { get; set; } = new List<BodyPart>();

    }

    public class BodyPart 
    {
        /// <summary>
        /// 修飾部位-中文名稱
        /// </summary>
        [SwaggerParameter(Description = "修飾部位-中文名稱")]
        public string ChiName { get; set; }

        /// <summary>
        /// 修飾部位-英文名稱
        /// </summary>
        [SwaggerParameter(Description = "修飾部位-英文名稱")]
        public string EnName { get; set; }

        /// <summary>
        /// 修飾部位-選項
        /// </summary>
        [SwaggerParameter(Description = "修飾部位-選項")]
        public List<FlatterPartOption> Options { get; set; } = new List<FlatterPartOption>();
    }

    public class FlatterPartOption
    {
        /// <summary>
        /// 修飾部位-選項編號
        /// </summary>
        [SwaggerParameter(Description = "修飾部位-選項編號")]
        public string No { get; set; }

        /// <summary>
        /// 修飾部位-選項名稱
        /// </summary>
        [SwaggerParameter(Description = "修飾部位-選項名稱")]
        public string Name { get; set; }
    }
}
