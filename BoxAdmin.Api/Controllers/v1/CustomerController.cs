using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Api.Controllers.v1
{
    using BoxAdmin.Framework.Results;
    using BoxAdmin.Application.Features.Customers.Queries.GetCustomerById;

    [Authorize]
    public class CustomerController : BaseApiController
    {
        /// <summary>
        /// 會員資料
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v{version}/customer/xxxxxxx-xxxxxxx-xxxxxxx-xxxx/get
        ///     
        /// Sample Resposne:
        /// 
        ///     {
        ///       "id": "b05125ab-3988-43af-8f4a-149fb1baaa7a",
        ///       "name": "BOT",
        ///       "sex": "男",
        ///       "birthday": "1911-01-01T00:00:00",
        ///       "mobile": "0912345678",
        ///       "email": "bot@obdesign.com.tw",
        ///       "zip": "123",
        ///       "city": "台北",
        ///       "region": "中正區",
        ///       "address": "xxxxxx",
        ///       "country": "台灣",
        ///       "surveyGroups": [
        ///         {
        ///           "id": "A21",
        ///           "groupName": "個人",
        ///           "items": [
        ///             { "title": "生日", "answer": "1911/01/01" },
        ///             { "title": "年齡", "answer": "12" }
        ///           ]
        ///         }
        ///       ]
        ///     }
        /// 
        /// </remarks>
        /// <param name="id">會員ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/get")]
        [Produces("application/json")]
        [SwaggerResponse(200, "會員資料", typeof(GetCustomerByIdResponse))]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(Result<GetCustomerByIdResponse>.Success(await _mediator.Send(new GetCustomerByIdQuery() { Id = id })));
        }
    }
}
