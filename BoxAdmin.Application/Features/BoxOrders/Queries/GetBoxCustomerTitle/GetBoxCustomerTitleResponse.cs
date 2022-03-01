using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxCustomerTitle
{
    public class GetBoxCustomerTitleResponse
    {
        /// <summary>
        /// 會員帳號
        /// </summary>
        [SwaggerParameter(Description = "會員帳號")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 會員姓名
        /// </summary>
        [SwaggerParameter(Description = "會員姓名")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 方案別
        /// </summary>
        [SwaggerParameter(Description = "方案別")]
        public string SubscribeTypeName { get; set; }

        /// <summary>
        /// 訂閱效期
        /// </summary>
        [SwaggerParameter(Description = "訂閱效期")]
        public string DueDate { get; set; }

        //Box使用次數

    }
}
