using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

using BoxAdmin.Framework.Results;

using BoxAdmin.Application.Features.Coupons.Queries.GetCoupons;
using BoxAdmin.Application.Features.Coupons.Queries.GetCouponType;
using BoxAdmin.Application.Features.Coupons.Queries.GetCouponById;
using BoxAdmin.Application.Features.Coupons.Queries.GetCouponDetail;
using BoxAdmin.Application.Features.Coupons.Queries.GetCouponByType;
using BoxAdmin.Application.Features.Coupons.Commands.CouponSubmit;
using BoxAdmin.Application.Features.Coupons.Commands.CouponRemove;
using BoxAdmin.Application.Features.Coupons.Commands.MarketingActivitiesSendTargetListSubmit;

using System.Data;
using ExcelDataReader;



namespace BoxAdmin.Api.Controllers.v1
{
    [Authorize]
    public class CouponController : BaseApiController
    {
        /// <summary>
        /// Coupon清單
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/coupon/getCoupons
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getCoupons")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Coupon清單", typeof(List<GetCouponsResponse>))]
        public async Task<IActionResult> GetAll([FromQuery] GetCouponsQuery command)
        {
            //return Ok(await _mediator.Send(command));
            return Ok(Result<List<GetCouponsResponse>>.Success(await _mediator.Send(command)));
        }


        /// <summary>
        /// 取所有Coupon類型
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/coupon/getCouponType
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getCouponType")]
        [Produces("application/json")]
        [SwaggerResponse(200, "取所有Coupon類型", typeof(List<GetCouponTypeResponse>))]
        public async Task<IActionResult> GetCouponType([FromQuery] GetCouponTypeQuery command)
        {
            //return Ok(await _mediator.Send(command));
            return Ok(Result<List<GetCouponTypeResponse>>.Success(await _mediator.Send(command)));
        }


        /// <summary>
        /// 以ID取Coupon資料
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/coupon/{id}/getCouponById
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/getCouponById")]
        [Produces("application/json")]
        [SwaggerResponse(200, "以ID取Coupon資料", typeof(GetCouponByIdResponse))]
        public async Task<IActionResult> GetCouponById([FromRoute] string id)
        {
            return Ok(Result<GetCouponByIdResponse>.Success(await _mediator.Send(new GetCouponByIdQuery() { Id = id })));
            //return Ok(await _mediator.Send((new GetCouponByIdQuery() { Id = id })));
        }


        /// <summary>
        /// Coupon明細
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/coupon/getCouponDetail
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("getCouponDetail")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Coupon明細", typeof(GetCouponDetailResponse))]
        public async Task<IActionResult> GetCouponDetail([FromQuery] GetCouponDetailQuery command)
        {
            //return Ok(await _mediator.Send(command));
            return Ok(Result<GetCouponDetailResponse>.Success(await _mediator.Send(command)));
        }


        /// <summary>
        /// 以Coupon類型取Coupon資料(自動歸戶機制)
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/coupon/{CouponType}/getCouponByType
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("{CouponType}/getCouponByType")]
        [Produces("application/json")]
        [SwaggerResponse(200, "以Coupon類型取Coupon資料(自動歸戶機制)", typeof(GetCouponByTypeResponse))]
        //public async Task<IActionResult> GetCouponByType(int CouponType)
        public async Task<IActionResult> GetCouponByType([FromRoute] int CouponType)
        {
            return Ok(Result<GetCouponByTypeResponse>.Success(await _mediator.Send(new GetCouponByTypeQuery() { CouponType = CouponType })));
        }


        /// <summary>
        /// 新增或更新Coupon
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/coupon/submit
        ///     
        /// Sample Resposne:
        /// 
        ///     {
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("submit")]
        [Produces("application/json")]
        [SwaggerResponse(200, "新增或更新Coupon", typeof(CouponSubmitResponse))]
        public async Task<IActionResult> Submit(CouponSubmitCommand command)
        {
            return Ok(Result<CouponSubmitResponse>.Success(await _mediator.Send(command)));
        }

        /// <summary>
        /// 移除Coupon
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/coupon/remove
        ///     
        /// Sample Resposne:
        /// 
        ///     {
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("remove")]
        [Produces("application/json")]
        [SwaggerResponse(200, "移除Coupon", typeof(CouponRemoveResponse))]
        public async Task<IActionResult> Remove(CouponRemoveCommand command)
        {
            return Ok(Result<CouponRemoveResponse>.Success(await _mediator.Send(command)));
        }


        /// <summary>
        /// 新增指定會員
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/coupon/sendtargetsubmit
        ///     
        /// Sample Resposne:
        /// 
        ///     {
        ///     }
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("sendtargetsubmit")]
        [Produces("application/json")]
        [SwaggerResponse(200, " 新增指定會員", typeof(MarketingActivitiesSendTargetListSubmitResponse))]
        public async Task<IActionResult> SendTargetSubmit(MarketingActivitiesSendTargetListSubmitCommand command)
        {
            return Ok(Result<MarketingActivitiesSendTargetListSubmitResponse>.Success(await _mediator.Send(command)));
        }



        /// <summary>
        /// 上傳指定會員
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     POST /api/v1/coupon/uploadmemberslist
        /// </remarks>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("uploadmemberslist")]
        public async Task<IActionResult> UploadMembersList([FromForm] IFormFile file)
        {
            using var stream = new System.IO.MemoryStream();
            await file.CopyToAsync(stream);

            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet ds = excelReader.AsDataSet();

            MarketingActivitiesSendTargetListSubmitCommand command = new MarketingActivitiesSendTargetListSubmitCommand();

            if (ds != null && ds.Tables != null) 
            {
                command.SendTargetList = new List<SendTarget>();

                for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
                {
                    SendTarget sendTarget = new SendTarget();

                    DataRow rw = ds.Tables[0].Rows[i];
                    sendTarget.MarketingActivitiesId = new Guid(rw.ItemArray[0].ToString());
                    sendTarget.Account = rw.ItemArray[1].ToString();
                    
                    command.SendTargetList.Add(sendTarget);
                }

                excelReader.Close();
            }

            return Ok(Result<MarketingActivitiesSendTargetListSubmitResponse>.Success(await _mediator.Send(command)));

            //var response = await _mediator.Send(new StyleBookImageSubmitCommand(id, stream, file.FileName));
            //return Ok(Result<StyleBookImageSubmitResponse>.Success(response));

        }


    }
}
