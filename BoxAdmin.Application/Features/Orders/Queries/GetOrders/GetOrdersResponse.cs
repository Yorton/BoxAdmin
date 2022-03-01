using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Orders.Queries.GetOrders
{
    public class GetOrdersResponse
    {
        /// <summary>
        /// 購物訂單編號
        /// </summary>
        [SwaggerParameter(Description = "購物訂單編號")]
        public string TransactionNo { get; set; }

        /// <summary>
        /// 會員ID
        /// </summary>
        [SwaggerParameter(Description = "會員ID")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 會員姓名
        /// </summary>
        [SwaggerParameter(Description = "會員姓名")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 訂單類型
        /// </summary>
        [SwaggerParameter(Description = "訂單類型")]
        public int OrderType { get; set; }

        /// <summary>
        /// 訂單類型名稱
        /// </summary>
        [SwaggerParameter(Description = "訂單類型名稱")]
        public string OrderTypeName { get; set; }

        /// <summary>
        /// 到貨時間
        /// </summary>
        [SwaggerParameter(Description = "到貨時間")]
        public DateTime? DevileryTime { get; set; }

        /// <summary>
        /// 付款時間
        /// </summary>
        [SwaggerParameter(Description = "付款時間")]
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 鑑賞期
        /// </summary>
        [SwaggerParameter(Description = "鑑賞期")]
        public DateTime? AppreciationTime { get; set; }

        /// <summary>
        /// 成立時間
        /// </summary>
        [SwaggerParameter(Description = "成立時間")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        [SwaggerParameter(Description = "訂單狀態")]
        public int OrderState { get; set; }

        /// <summary>
        /// 訂單狀態名稱
        /// </summary>
        [SwaggerParameter(Description = "訂單狀態名稱")]
        public string OrderStateName { get; set; }
    }
}
