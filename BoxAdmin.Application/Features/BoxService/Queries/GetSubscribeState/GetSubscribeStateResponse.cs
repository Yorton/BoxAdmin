using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeState
{
    public class GetSubscribeStateResponse
    {
        /// <summary>
        /// 訂閱狀態ID
        /// </summary>
        [SwaggerParameter(Description = "訂閱狀態ID")]
        public int Id { get; set; }

        /// <summary>
        /// 訂閱狀態名稱
        /// </summary>
        [SwaggerParameter(Description = "訂閱狀態名稱")]
        public string Name { get; set; }
    }
}
