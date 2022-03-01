using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxStatus
{
    public class GetBoxStatusResponse
    {
        /// <summary>
        /// Box狀態ID
        /// </summary>
        [SwaggerParameter(Description = "Box狀態ID")]
        public int Id { get; set; }

        /// <summary>
        /// Box狀態名稱
        /// </summary>
        [SwaggerParameter(Description = "Box狀態名稱")]
        public string Name { get; set; }
    }
}
