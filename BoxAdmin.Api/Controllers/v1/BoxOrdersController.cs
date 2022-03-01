using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

using BoxAdmin.Framework.Results;

using BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxOrders;
using BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxStatus;
using BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxMatchmaker;

using BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxReservation;
using BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxCustomerTitle;

using BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxDetail;
using BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxSurveyAnswer;

namespace BoxAdmin.Api.Controllers.v1
{
    [Authorize]
    public class BoxOrdersController : BaseApiController
    {

        /// <summary>
        /// Box清單
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxorders/getBoxOrders
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getBoxOrders")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Box清單", typeof(List<GetBoxOrdersResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetBoxOrdersQuery command)
        {
            //return Ok(await _mediator.Send(command));
            return Ok(Result<List<GetBoxOrdersResponse>>.Success(await _mediator.Send(command)));
        }

       

        /// <summary>
        /// Box狀態
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxorders/getBoxStatus
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getBoxStatus")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Box狀態", typeof(List<GetBoxStatusResponse>))]
        public async Task<IActionResult> GetBoxStatus([FromQuery] GetBoxStatusQuery command)
        {
            //return Ok(await _mediator.Send(command));
            return Ok(Result<List<GetBoxStatusResponse>>.Success(await _mediator.Send(command)));
        }


        /// <summary>
        /// 搭配師
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxorders/getMatchmakers
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getMatchmakers")]
        [Produces("application/json")]
        [SwaggerResponse(200, "搭配師", typeof(List<GetBoxMatchmakerResponse>))]
        public async Task<IActionResult> GetMatchmakers([FromQuery] GetBoxMatchmakerQuery command)
        {
            //return Ok(await _mediator.Send(command));
            return Ok(Result<List<GetBoxMatchmakerResponse>>.Success(await _mediator.Send(command)));
        }


        /// <summary>
        /// Box預約單
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxorders/getBoxReservation
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getBoxReservation")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Box預約單", typeof(List<GetBoxReservationResponse>))]
        public async Task<IActionResult> GetBoxReservation([FromQuery] GetBoxReservationQuery command)
        {
            //return Ok(await _mediator.Send(command));
            return Ok(Result<List<GetBoxReservationResponse>>.Success(await _mediator.Send(command)));
        }

        /// <summary>
        /// 會員資訊-Title
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxorders/getCustomerTitle
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getCustomerTitle")]
        [Produces("application/json")]
        [SwaggerResponse(200, "會員資訊-Title", typeof(GetBoxCustomerTitleResponse))]
        public async Task<IActionResult> GetCustomerTitle([FromQuery] GetBoxCustomerTitleQuery command)
        {
            //return Ok(await _mediator.Send(command));
            return Ok(Result<GetBoxCustomerTitleResponse>.Success(await _mediator.Send(command)));
        }



        /// <summary>
        /// 以ID取Box預約明細資料 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxorders/{id}/getBoxDetailById
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/getBoxDetailById")]
        [Produces("application/json")]
        [SwaggerResponse(200, "以ID取Box預約明細資料", typeof(GetBoxDetailResponse))]
        public async Task<IActionResult> GetBoxDetailById([FromRoute] string id)
        {
            return Ok(Result<GetBoxDetailResponse>.Success(await _mediator.Send(new GetBoxDetailQuery() { Id = id })));
        }


        /// <summary>
        /// 問卷
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxorders/getBoxSurveyAnswer
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getBoxSurveyAnswer")]
        [Produces("application/json")]
        [SwaggerResponse(200, "問卷", typeof(List<GetBoxSurveyAnswerResponse>))]
        public async Task<IActionResult> GetBoxSurveyAnswer([FromQuery] GetBoxSurveyAnswerQuery command)
        {
            return Ok(Result<List<GetBoxSurveyAnswerResponse>>.Success(await _mediator.Send(command)));
        }
    }
}
