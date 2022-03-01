using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeDetail
{
    public class GetSubscribeDetailResponse
    {
        /// <summary>
        /// 服務訂單主檔
        /// </summary>
        [SwaggerParameter(Description = "服務訂單主檔")]
        public MainSubscribe MainSubscribeData { get; set; }

        /// <summary>
        /// 訂閱資訊
        /// </summary>
        [SwaggerParameter(Description = "訂閱資訊")]
        public SubscribeInfo SubscribeInfoData { get; set; }

        //問卷

        /// <summary>
        /// Box預約單
        /// </summary>
        [SwaggerParameter(Description = "Box預約單")]
        public List<BoxReservation> BoxReservationData { get; set; }
    }

    public class MainSubscribe
    {
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
        /// 申請暫停
        /// </summary>
        [SwaggerParameter(Description = "申請暫停")]
        public string SuspendName { get; set; }

        /// <summary>
        /// 成立方式
        /// </summary>
        [SwaggerParameter(Description = "成立方式")]
        public string CreatedMethodName { get; set; }


        /// <summary>
        /// 訂單編號
        /// </summary>
        [SwaggerParameter(Description = "訂單編號")]
        public string SourceTransactionNo { get; set; }


        /// <summary>
        /// 成立時間
        /// </summary>
        [SwaggerParameter(Description = "成立時間")]
        public string CreatedMethodTime { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        [SwaggerParameter(Description = "付款方式")]
        public string PaymentWay { get; set; }

        /// <summary>
        /// 發票開立
        /// </summary>
        [SwaggerParameter(Description = "發票開立")]
        public string Invoicing { get; set; }
    }

    public class SubscribeInfo 
    {
        /// <summary>
        /// 季卡價格
        /// </summary>
        [SwaggerParameter(Description = "季卡價格")]
        public int PlanPrice { get; set; }

        /// <summary>
        /// 折價券數量
        /// </summary>
        [SwaggerParameter(Description = "折價券數量")]
        public int DiscountQuantity { get; set; }

        /// <summary>
        /// 加盒券數量
        /// </summary>
        [SwaggerParameter(Description = "加盒券數量")]
        public int BoxAddedQuantity { get; set; }

        /// <summary>
        /// 付款金額
        /// </summary>
        [SwaggerParameter(Description = "付款金額")]
        public int PaymentAmount { get; set; }
    }

    public class BoxReservation 
    {

        /// <summary>
        /// Box編號
        /// </summary>
        [SwaggerParameter(Description = "Box編號")]
        public string BoxNo { get; set; }

        /// <summary>
        /// 預約完成時間
        /// </summary>
        [SwaggerParameter(Description = "預約完成時間")]
        public string ReservationDueTime { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [SwaggerParameter(Description = "狀態")]
        public string Status { get; set; }
    }
}
