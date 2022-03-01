using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxOrders
{
    public class GetBoxOrdersResponse
    {
        /// <summary>
        /// BOX預約單ID
        /// </summary>
        [SwaggerParameter(Description = "BOX預約單ID")]
        public string Id { get; set; }

        /// <summary>
        /// BOX訂閱盒編號
        /// </summary>
        [SwaggerParameter(Description = "BOX訂閱盒編號")]
        public string BoxNo { get; set; }

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
        /// 期望配送日期
        /// </summary>
        [SwaggerParameter(Description = "期望配送日期")]
        public string DeliveryExpected { get; set; }

        //是否表態 出貨時間 配達時間 試穿期限


        /// <summary>
        /// 狀態ID
        /// </summary>
        [SwaggerParameter(Description = "狀態ID")]
        public int StatusId { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [SwaggerParameter(Description = "狀態")]
        public string StatusName { get; set; }
    }
}
