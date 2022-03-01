using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Coupons.Queries.GetCouponDetail
{
    public class GetCouponDetailResponse
    {
        /// <summary>
        /// Coupon活動時間
        /// </summary>
        [SwaggerParameter(Description = "Coupon活動時間")]
        public string MarketingActivityDate { get; set; }

        /// <summary>
        ///產出類型- 1.即時產出 2.預先產出 
        /// </summary>
        [SwaggerParameter(Description = "產出類型")]
        public string OutputTypeName { get; set; }

        /// <summary>
        /// 已產生的筆數
        /// </summary>
        [SwaggerParameter(Description = "已產生的筆數")]
        public int ProducedCount { get; set; }

        /// <summary>
        /// 已領取的筆數
        /// </summary>
        [SwaggerParameter(Description = "已領取的筆數")]
        public int ReceivedCount { get; set; }

        /// <summary>
        /// 已使用的筆數
        /// </summary>
        [SwaggerParameter(Description = "已使用的筆數")]
        public int UsedCount { get; set; }

        /// <summary>
        /// Coupon明細資料
        /// </summary>
        [SwaggerParameter(Description = "Coupon ID")]
        public List<CouponDetail> CouponDetailList { get; set; }
    }


    public class CouponDetail 
    {
        /// <summary>
        /// Coupon ID
        /// </summary>
        [SwaggerParameter(Description = "Coupon ID")]
        public string Id { get; set; }

        /// <summary>
        /// Coupon名稱
        /// </summary>
        [SwaggerParameter(Description = "Coupon名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 指定碼
        /// </summary>
        [SwaggerParameter(Description = "指定碼")]
        public string SpecialCode { get; set; }

        /// <summary>
        /// 會員帳號
        /// </summary>
        [SwaggerParameter(Description = "會員帳號")]
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// 領取時間
        /// </summary>
        [SwaggerParameter(Description = "領取時間")]
        public string ReceivedDate { get; set; }

        /// <summary>
        /// 可以使用的時間
        /// </summary>
        [SwaggerParameter(Description = "可以使用的時間")]
        public string CanUseDate { get; set; }

        /// <summary>
        /// 實際使用的時間
        /// </summary>
        [SwaggerParameter(Description = "實際使用的時間")]
        public string UsedDate { get; set; }

        /// <summary>
        /// 使用訂單
        /// </summary>
        [SwaggerParameter(Description = "使用訂單")]
        public Guid? TransactionId { get; set; }
    }

}
