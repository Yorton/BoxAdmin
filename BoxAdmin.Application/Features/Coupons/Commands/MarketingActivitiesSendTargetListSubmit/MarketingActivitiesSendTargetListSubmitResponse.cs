using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Coupons.Commands.MarketingActivitiesSendTargetListSubmit
{
    public class MarketingActivitiesSendTargetListSubmitResponse
    {
        /// <summary>
        /// 已上傳筆數
        /// </summary>
        [SwaggerParameter(Description = "已上傳筆數")]
        public int UploadedCount { get; set; }
    }
}
