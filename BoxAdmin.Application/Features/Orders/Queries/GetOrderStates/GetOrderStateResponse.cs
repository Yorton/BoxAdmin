using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Orders.Queries.GetOrderStates
{
    public class GetOrderStateResponse
    {
        /// <summary>
        /// 訂單狀態名稱
        /// </summary>
        [SwaggerParameter(Description = "訂單狀態名稱")]
        public string Text { get; set; }

        /// <summary>
        /// 訂單狀態ID
        /// </summary>
        [SwaggerParameter(Description = "訂單狀態ID")]
        public int Value { get; set; }
    }
}
