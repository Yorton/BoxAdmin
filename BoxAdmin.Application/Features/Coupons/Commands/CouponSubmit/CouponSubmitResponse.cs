﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Coupons.Commands.CouponSubmit
{
    public class CouponSubmitResponse
    {
        /// <summary>
        /// 回傳訊息
        /// </summary>
        [SwaggerParameter(Description = "回傳訊息")]
        public string Message { get; set; }
    }
}
