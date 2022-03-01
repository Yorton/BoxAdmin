using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Coupons.Queries.GetCoupons
{
    public class GetCouponsResponse
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
        public string CouponName { get; set; }

        /// <summary>
        /// Coupon類型
        /// </summary>
        [SwaggerParameter(Description = "Coupon類型")]
        public int CouponType { get; set; }

        /// <summary>
        /// Coupon類型名稱
        /// </summary>
        [SwaggerParameter(Description = "Coupon類型名稱")]
        public string CouponTypeName { get; set; }

        /// <summary>
        /// 活動時間開始日
        /// </summary>
        [SwaggerParameter(Description = "活動時間開始日")]
        public string MarketingActivityStartDate { get; set; }

        /// <summary>
        /// 活動時間結束日
        /// </summary>
        [SwaggerParameter(Description = "活動時間結束日")]
        public string MarketingActivityEndDate { get; set; }

        /// <summary>
        /// 可以使用開始日
        /// </summary>
        [SwaggerParameter(Description = "可以使用開始日")]
        public string CanUseStartDate { get; set; }

        /// <summary>
        /// 可以使用結束日
        /// </summary>
        [SwaggerParameter(Description = "可以使用結束日")]
        public string CanUseEndDate { get; set; }

        /// <summary>
        /// 優惠項目
        /// </summary>
        [SwaggerParameter(Description = "優惠項目")]
        public string CartType { get; set; }


        /// <summary>
        /// 優惠目標
        /// </summary>
        [SwaggerParameter(Description = "優惠目標")]
        public int DiscountTarget { get; set; }

        /// <summary>
        /// 優惠目標名稱
        /// </summary>
        [SwaggerParameter(Description = "優惠目標名稱")]
        public string DiscountTargetName { get; set; }

        /// <summary>
        /// 優惠內容類型
        /// </summary>
        [SwaggerParameter(Description = "優惠內容類型")]
        public int DiscountContentType { get; set; }

        /// <summary>
        /// 優惠內容類型名稱
        /// </summary>
        [SwaggerParameter(Description = "優惠內容類型名稱")]
        public string DiscountContentTypeName { get; set; }

        /// <summary>
        /// 優惠內容值
        /// </summary>
        [SwaggerParameter(Description = "優惠內容值")]
        public int DiscountContentValue { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [SwaggerParameter(Description = "狀態")]
        public string Status { get; set; }
    }
}
