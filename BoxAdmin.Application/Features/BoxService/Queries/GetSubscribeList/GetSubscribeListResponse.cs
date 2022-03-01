using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeList
{
    public class GetSubscribeListResponse
    {
        /// <summary>
        /// 訂閱服務Id(等同訂單購物車ID)
        /// </summary>
        [SwaggerParameter(Description = "訂閱服務Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// 服務訂單編號
        /// </summary>
        [SwaggerParameter(Description = "服務訂單編號")]
        public string SubscribeNo { get; set; }

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
        /// 購買方案
        /// </summary>
        [SwaggerParameter(Description = "購買方案")]
        public string PurchasePlan { get; set; }


        /// <summary>
        /// 成立方式
        /// </summary>
        [SwaggerParameter(Description = "成立方式")]
        public string CreatedMethod { get; set; }

        /// <summary>
        /// Box已啟用數
        /// </summary>
        [SwaggerParameter(Description = "Box已啟用數")]
        public string BoxEnalbedCount { get; set; }

        //申請暫停

        /// <summary>
        /// 訂閱狀態ID
        /// </summary>
        [SwaggerParameter(Description = "訂閱狀態ID")]
        public int SubscribeStatusId { get; set; }

        /// <summary>
        /// 訂閱狀態
        /// </summary>
        [SwaggerParameter(Description = "訂閱狀態")]
        public string SubscribeStatus { get; set; }

        /// <summary>
        /// 訂閱結束時間
        /// </summary>
        [SwaggerParameter(Description = "訂閱結束時間")]
        public string DueTime { get; set; }

    }
}
