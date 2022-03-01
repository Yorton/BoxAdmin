using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using BoxAdmin.Application.Features.Orders.Queries.GetOrders;
using Swashbuckle.AspNetCore.Annotations;
using BoxAdmin.Application.Features.Orders.Queries.GetOrderInfo;
using BoxAdmin.Application.Features.Orders.Queries.GetOrderStates;
using BoxAdmin.Framework.Results;

namespace BoxAdmin.Api.Controllers.v1
{
    public class OrderController : BaseApiController
    {
        /// <summary>
        /// 購物訂單
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/order/getorders
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getorders")]
        [Produces("application/json")]
        [SwaggerResponse(200, "購物訂單", typeof(List<GetOrdersResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetOrdersQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        /// <summary>
        /// 以TransactionNo取訂單詳細資料
        /// </summary>
        /// Sample request:
        ///
        ///     GET /api/v1/order/{transactionNo}/getorderinfo
        ///     
        /// <returns></returns>
        [HttpGet]
        [Route("{transactionNo}/detail")]
        [Produces("application/json")]
        [SwaggerResponse(200, "以TransactionNo取訂單詳細資料", typeof(GetOrderInfoResponse))]
        public async Task<IActionResult> GetInfo([FromRoute] string transactionNo)
        { 
            return Ok(Result<GetOrderInfoResponse>.Success(await _mediator.Send(new GetOrderInfoQuery() { TransactionNo = transactionNo })));
        }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getorderstates")]
        [Produces("application/json")]
        [SwaggerResponse(200, "訂單狀態", typeof(List<GetOrderStateResponse>))]
        public async Task<IActionResult> GetOrderStates([FromQuery] GetOrderStateQuery command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
