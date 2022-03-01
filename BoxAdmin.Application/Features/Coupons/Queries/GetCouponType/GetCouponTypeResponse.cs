using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Coupons.Queries.GetCouponType
{
    public class GetCouponTypeResponse
    {
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
    }
}
