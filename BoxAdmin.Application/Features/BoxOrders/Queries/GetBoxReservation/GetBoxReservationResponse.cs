using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxReservation
{
    public class GetBoxReservationResponse
    {
        /// <summary>
        /// BOX訂閱盒編號
        /// </summary>
        [SwaggerParameter(Description = "BOX訂閱盒編號")]
        public string BoxNo { get; set; }

        /// <summary>
        /// 期望配送日期
        /// </summary>
        [SwaggerParameter(Description = "期望配送日期")]
        public string DeliveryExpected { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [SwaggerParameter(Description = "狀態")]
        public string StatusName { get; set; }

        /// <summary>
        /// 搭配師ID
        /// </summary>
        [SwaggerParameter(Description = "搭配師ID")]
        public Guid MatchmakerId { get; set; }

        /// <summary>
        /// 搭配師
        /// </summary>
        [SwaggerParameter(Description = "搭配師")]
        public string MatchmakerName { get; set; }

        /// <summary>
        /// 會員ID
        /// </summary>
        [SwaggerParameter(Description = "會員ID")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 訂閱方案
        /// </summary>
        [SwaggerParameter(Description = "訂閱方案")]
        public string SubscriptionPlanName { get; set; }

        /// <summary>
        /// 是否加購
        /// </summary>
        [SwaggerParameter(Description = "是否加購")]
        public string AddPurchaseName { get; set; }

    }
}
