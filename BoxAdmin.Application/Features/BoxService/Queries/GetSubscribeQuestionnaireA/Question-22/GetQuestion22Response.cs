using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_22
{
    public class GetQuestion22Response
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
        /// 產業
        /// </summary>
        [SwaggerParameter(Description = "產業")]
        public Industry Industry { get; set; }

        /// <summary>
        /// 職能
        /// </summary>
        [SwaggerParameter(Description = "職能")]
        public Competency Competency { get; set; }

        /// <summary>
        /// 管理職
        /// </summary>
        [SwaggerParameter(Description = "管理職")]
        public Management Management { get; set; }
    }


    public class Industry 
    {
        /// <summary>
        /// 產業名稱-英文
        /// </summary>
        [SwaggerParameter(Description = "產業名稱-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 產業名稱-中文
        /// </summary>
        [SwaggerParameter(Description = "產業名稱-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<JobOption> Options { get; set; } = new List<JobOption>();
    }

    
    public class Competency
    {
        /// <summary>
        /// 職能名稱-英文
        /// </summary>
        [SwaggerParameter(Description = "職能名稱-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 職能名稱-中文
        /// </summary>
        [SwaggerParameter(Description = "職能名稱-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<JobOption> Options { get; set; } = new List<JobOption>();
    }

   
    public class Management
    {
        /// <summary>
        /// 管理職名稱-英文
        /// </summary>
        [SwaggerParameter(Description = "管理職名稱-英文")]
        public string EnName { get; set; }

        /// <summary>
        /// 管理職名稱-中文
        /// </summary>
        [SwaggerParameter(Description = "管理職名稱-中文")]
        public string ChiName { get; set; }

        /// <summary>
        /// 選項
        /// </summary>
        [SwaggerParameter(Description = "選項")]
        public List<JobOption> Options { get; set; } = new List<JobOption>();
    }

    public class JobOption
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
