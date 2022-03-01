using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Coupons.Queries.GetCouponByType
{
    public class GetCouponByTypeResponse
    {
        /// <summary>
        /// Coupon ID
        /// </summary>
        [SwaggerParameter(Description = "Coupon ID")]
        public string Id { get; set; }

        /// <summary>
        /// CouponRule ID
        /// </summary>
        [SwaggerParameter(Description = "CouponRule ID")]
        public Guid CouponRuleId { get; set; }

        /// <summary>
        /// MarketingActivities ID
        /// </summary>
        [SwaggerParameter(Description = "MarketingActivities ID")]
        public Guid? MarketingActivitiesId { get; set; }

  
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
        /// 領取/歸戶方式
        /// </summary>
        [SwaggerParameter(Description = "領取/歸戶方式")]
        public int ReceiveType { get; set; }

        /// <summary>
        /// 領取/歸戶方式名稱
        /// </summary>
        //[SwaggerParameter(Description = "領取/歸戶方式名稱")]
        //public string ReceiveTypeName { get; set; }

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
        /// 指定發送時間點  0: 無 1. 系統自動取用 2. 每個月[N]號 3. 訂單成立後[N]分鐘
        /// </summary>
        [SwaggerParameter(Description = "指定發送時間點")]
        public int SendTimePoint { get; set; }

        /// <summary>
        /// 發送條件
        /// </summary>
        [SwaggerParameter(Description = "發送條件")]
        public int SendCondition { get; set; }

        /// <summary>
        /// 發送條件名稱
        /// </summary>
        //[SwaggerParameter(Description = "發送條件名稱")]
        //public string SendConditionName { get; set; }

        /// <summary>
        /// 發送限制
        /// </summary>
        [SwaggerParameter(Description = "發送限制")]
        public int SendLimitType { get; set; }

        /// <summary>
        /// 發送限制名稱
        /// </summary>
        //[SwaggerParameter(Description = "發送限制名稱")]
        //public string SendLimitTypeName { get; set; }


        /// <summary>
        /// 可用時間選項- 0.系統自動取用 1.時間區間 2.歸戶後[N]天內可使用 
        /// </summary>
        [SwaggerParameter(Description = "可用時間選項")]
        public int CanUseType { get; set; }

        /// <summary>
        /// 使用限制
        /// </summary>
        [SwaggerParameter(Description = "使用限制")]
        public int UseLimitType { get; set; }

        /// <summary>
        /// 使用限制名稱
        /// </summary>
        //[SwaggerParameter(Description = "使用限制名稱")]
        //public string UseLimitTypeName { get; set; }

        /// <summary>
        /// 產出類型
        /// </summary>
        [SwaggerParameter(Description = "產出類型")]
        public int OutputType { get; set; }

        /// <summary>
        /// 對象
        /// </summary>
        [SwaggerParameter(Description = "對象")]
        public int SendTarget { get; set; }

        /// <summary>
        /// 對象名稱
        /// </summary>
        //[SwaggerParameter(Description = "對象名稱")]
        //public string SendTargetName { get; set; }

        /// <summary>
        /// 優惠項目
        /// </summary>
        [SwaggerParameter(Description = "優惠項目")]
        public string CartType { get; set; }


        /// <summary>
        /// 優惠門檻類型
        /// </summary>
        [SwaggerParameter(Description = "優惠門檻類型")]
        public int DiscountThresholdType { get; set; }

        /// <summary>
        /// 優惠門檻類型名稱
        /// </summary>
        //[SwaggerParameter(Description = "優惠門檻類型名稱")]
        //public string DiscountThresholdTypeName { get; set; }

        /// <summary>
        /// 優惠門檻值
        /// </summary>
        [SwaggerParameter(Description = "優惠門檻值")]
        public int? DiscountThresholdValue { get; set; }

        /// <summary>
        /// 優惠目標
        /// </summary>
        [SwaggerParameter(Description = "優惠目標")]
        public int DiscountTarget { get; set; }

        /// <summary>
        /// 優惠目標名稱
        /// </summary>
        //[SwaggerParameter(Description = "優惠目標名稱")]
        //public string DiscountTargetName { get; set; }


        /// <summary>
        /// 優惠內容類型
        /// </summary>
        [SwaggerParameter(Description = "優惠內容類型")]
        public int DiscountContentType { get; set; }

        /// <summary>
        /// 優惠內容類型名稱
        /// </summary>
        //[SwaggerParameter(Description = "優惠內容類型名稱")]
        //public string DiscountContentTypeName { get; set; }

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

