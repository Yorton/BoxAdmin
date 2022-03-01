using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

using BoxAdmin.Framework.Results;

using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeList;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeState;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeDetail;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeSurveyAnswer;

#region 問卷A

#region Question 
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_1;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_2;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_3;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_4;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_5;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_6;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_7;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_8;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_9;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_10;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_11;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_12;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_13;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_14;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_15;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_16;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_17;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_18;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_19;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_20;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_21;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_22;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_23;
using BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeQuestionnaireA.Question_24;

#endregion

#region Answer 

#endregion

#endregion


namespace BoxAdmin.Api.Controllers.v1
{
    [Authorize]
    public class BoxServiceController : BaseApiController
    {
        /// <summary>
        /// 服務訂單
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxservice/getSubscribeList
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getSubscribeList")]
        [Produces("application/json")]
        [SwaggerResponse(200, "服務訂單", typeof(List<GetSubscribeListResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetSubscribeListQuery command)

        {
            //return Ok(await _mediator.Send(command));
            return Ok(Result<List<GetSubscribeListResponse>>.Success(await _mediator.Send(command)));
        }


        /// <summary>
        /// 訂閱狀態
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxservice/getSubscribeState
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getSubscribeState")]
        [Produces("application/json")]
        [SwaggerResponse(200, "訂閱狀態", typeof(List<GetSubscribeStateResponse>))]
        public async Task<IActionResult> GetSubscribeState([FromQuery] GetSubscribeStateQuery command)
        {
            return Ok(await _mediator.Send(command));
        }



        /// <summary>
        /// 以ID取訂閱明細資料
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxservice/{id}/getSubscribeDetailById
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/getSubscribeDetailById")]
        [Produces("application/json")]
        [SwaggerResponse(200, "以ID取訂閱明細資料", typeof(GetSubscribeDetailResponse))]
        public async Task<IActionResult> GetSubscribeDetailById([FromRoute] string id)
        {
            return Ok(Result<GetSubscribeDetailResponse>.Success(await _mediator.Send(new GetSubscribeDetailQuery() { Id = id })));
        }

        /// <summary>
        /// 問卷
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/boxservice/getSubscribeSurveyAnswer
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getSubscribeSurveyAnswer")]
        [Produces("application/json")]
        [SwaggerResponse(200, "問卷", typeof(List<GetSubscribeSurveyAnswerResponse>))]
        public async Task<IActionResult> GetSubscribeSurveyAnswer([FromQuery] GetSubscribeSurveyAnswerQuery command)
        {
            return Ok(Result<List<GetSubscribeSurveyAnswerResponse>>.Success(await _mediator.Send(command)));
        }

        #region 問卷A(舊的不使用)

        #region Question
        ///// <summary>
        ///// 問卷A-第1題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question1
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question1")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第1題", typeof(GetQuestion1Response))]
        //public async Task<IActionResult> GetQuestion1([FromQuery] GetQuestion1Query command)
        //{
        //    return Ok(Result<GetQuestion1Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第2題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question2
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question2")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第2題", typeof(GetQuestion2Response))]
        //public async Task<IActionResult> GetQuestion2([FromQuery] GetQuestion2Query command)
        //{
        //    return Ok(Result<GetQuestion2Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第3題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question3
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question3")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第3題", typeof(GetQuestion3Response))]
        //public async Task<IActionResult> GetQuestion3([FromQuery] GetQuestion3Query command)
        //{
        //    return Ok(Result<GetQuestion3Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第4題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question4
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question4")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第4題", typeof(GetQuestion4Response))]
        //public async Task<IActionResult> GetQuestion4([FromQuery] GetQuestion4Query command)
        //{
        //    return Ok(Result<GetQuestion4Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第5題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question5
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question5")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第5題", typeof(GetQuestion5Response))]
        //public async Task<IActionResult> GetQuestion5([FromQuery] GetQuestion5Query command)
        //{
        //    return Ok(Result<GetQuestion5Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第6題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question6
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question6")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第6題", typeof(GetQuestion6Response))]
        //public async Task<IActionResult> GetQuestion6([FromQuery] GetQuestion6Query command)
        //{
        //    return Ok(Result<GetQuestion6Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第7題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question7
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question7")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第7題", typeof(GetQuestion7Response))]
        //public async Task<IActionResult> GetQuestion7([FromQuery] GetQuestion7Query command)
        //{
        //    return Ok(Result<GetQuestion7Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第8題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question8
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question8")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第8題", typeof(GetQuestion8Response))]
        //public async Task<IActionResult> GetQuestion8([FromQuery] GetQuestion8Query command)
        //{
        //    return Ok(Result<GetQuestion8Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第9題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question9
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question9")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第9題", typeof(GetQuestion9Response))]
        //public async Task<IActionResult> GetQuestion9([FromQuery] GetQuestion9Query command)
        //{
        //    return Ok(Result<GetQuestion9Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第10題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question10
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question10")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第10題", typeof(GetQuestion10Response))]
        //public async Task<IActionResult> GetQuestion10([FromQuery] GetQuestion10Query command)
        //{
        //    return Ok(Result<GetQuestion10Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第11題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question11
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question11")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第11題", typeof(GetQuestion11Response))]
        //public async Task<IActionResult> GetQuestion11([FromQuery] GetQuestion11Query command)
        //{
        //    return Ok(Result<GetQuestion11Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第12題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question12
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question12")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第12題", typeof(GetQuestion12Response))]
        //public async Task<IActionResult> GetQuestion12([FromQuery] GetQuestion12Query command)
        //{
        //    return Ok(Result<GetQuestion12Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第13題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question13
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question13")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第13題", typeof(GetQuestion13Response))]
        //public async Task<IActionResult> GetQuestion13([FromQuery] GetQuestion13Query command)
        //{
        //    return Ok(Result<GetQuestion13Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第14題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question14
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question14")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第14題", typeof(GetQuestion14Response))]
        //public async Task<IActionResult> GetQuestion14([FromQuery] GetQuestion14Query command)
        //{
        //    return Ok(Result<GetQuestion14Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第15題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question15
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question15")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第15題", typeof(GetQuestion15Response))]
        //public async Task<IActionResult> GetQuestion15([FromQuery] GetQuestion15Query command)
        //{
        //    return Ok(Result<GetQuestion15Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第16題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question16
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question16")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第16題", typeof(GetQuestion16Response))]
        //public async Task<IActionResult> GetQuestion16([FromQuery] GetQuestion16Query command)
        //{
        //    return Ok(Result<GetQuestion16Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第17題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question17
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question17")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第17題", typeof(GetQuestion17Response))]
        //public async Task<IActionResult> GetQuestion17([FromQuery] GetQuestion17Query command)
        //{
        //    return Ok(Result<GetQuestion17Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第18題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question18
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question18")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第18題", typeof(GetQuestion18Response))]
        //public async Task<IActionResult> GetQuestion18([FromQuery] GetQuestion18Query command)
        //{
        //    return Ok(Result<GetQuestion18Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第19題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question19
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question19")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第19題", typeof(GetQuestion19Response))]
        //public async Task<IActionResult> GetQuestion19([FromQuery] GetQuestion19Query command)
        //{
        //    return Ok(Result<GetQuestion19Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第20題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question20
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question20")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第20題", typeof(GetQuestion20Response))]
        //public async Task<IActionResult> GetQuestion20([FromQuery] GetQuestion20Query command)
        //{
        //    return Ok(Result<GetQuestion20Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第21題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question21
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question21")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第21題", typeof(GetQuestion21Response))]
        //public async Task<IActionResult> GetQuestion21([FromQuery] GetQuestion21Query command)
        //{
        //    return Ok(Result<GetQuestion21Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第22題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question22
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question22")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第22題", typeof(GetQuestion22Response))]
        //public async Task<IActionResult> GetQuestion21([FromQuery] GetQuestion22Query command)
        //{
        //    return Ok(Result<GetQuestion22Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第23題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question23
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question23")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第23題", typeof(GetQuestion23Response))]
        //public async Task<IActionResult> GetQuestion23([FromQuery] GetQuestion23Query command)
        //{
        //    return Ok(Result<GetQuestion23Response>.Success(await _mediator.Send(command)));
        //}

        ///// <summary>
        ///// 問卷A-第24題
        ///// </summary>
        ///// <remarks>
        ///// Sample request:
        /////
        /////     GET /api/v1/boxservice/QuestionnaireA/Question24
        /////     
        ///// </remarks>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("QuestionnaireA/Question24")]
        //[Produces("application/json")]
        //[SwaggerResponse(200, "問卷A-第24題", typeof(GetQuestion24Response))]
        //public async Task<IActionResult> GeQuestion24([FromQuery] GetQuestion24Query command)
        //{
        //    return Ok(Result<GetQuestion24Response>.Success(await _mediator.Send(command)));
        //}
        #endregion

        #region Answer

        #endregion

        #endregion

    }
}
