using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxMatchmaker
{
    public class GetBoxMatchmakerResponse
    {
        /// <summary>
        /// 搭配師ID
        /// </summary>
        [SwaggerParameter(Description = "搭配師ID")]
        public Guid Id { get; set; }

        /// <summary>
        /// 搭配師
        /// </summary>
        [SwaggerParameter(Description = "搭配師")]
        public string Name { get; set; }
    }
}
