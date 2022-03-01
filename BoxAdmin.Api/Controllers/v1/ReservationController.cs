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
    using BoxAdmin.Application.Features.Reservations.Queries;
    using BoxAdmin.Application.Features.Reservations.Queries.GetById;
    using BoxAdmin.Application.Features.Reservations.Queries.Get;
    using BoxAdmin.Application.Features.Reservations.Queries.GetCardMessageTemplate;
    using BoxAdmin.Application.Features.Reservations.Commands.AddReservationLineItem;
    using BoxAdmin.Application.Features.Reservations.Commands.SubmitReservationGroup;
    using BoxAdmin.Application.Features.Reservations.Commands.SubmitReservationCard;
    using BoxAdmin.Application.Features.Reservations.Commands.Valudate;
    using BoxAdmin.Application.Features.Reservations.Commands.AddReservationOrder;

    [Authorize]
    public class ReservationController : BaseApiController
    {
        /// <summary>
        /// BOX預約單資訊
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v{version}/reservation/xxxxxxx-xxxxxxx-xxxxxxx-xxxx/get
        ///     
        /// Sample Resposne:
        /// 
        ///     {
        ///       "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///       "subscribeId": "a5d9f0a0-46cb-43a7-8f58-2e8dd7ae9d45",
        ///       "customerId": "b05125ab-3988-43af-8f4a-149fb1baaa7a",
        ///       "boxNo": "B202001210123456",
        ///       "matchmakerId": "7a65248e-efdb-4070-b2c9-5a7ec94290ee",
        ///       "itemGroups": [
        ///         {
        ///           "id": "0cb022db-3850-492a-b823-2fe874d66187",
        ///           "reservationId": "00000000-0000-0000-0000-000000000000",
        ///           "matchingMessage": "00000000-0000-0000-0000-000000000000",
        ///           "styleId": "00000000-0000-0000-0000-000000000000",
        ///           "occasionId": "00000000-0000-0000-0000-000000000000",
        ///           "sortNum": "1",
        ///           "createdAt": null,
        ///           "createdBy": null,
        ///           "items": [
        ///             {
        ///               "id": "8a5742a3-445d-4b08-9d14-85d69bc0483f",
        ///               "reservationId": "00000000-0000-0000-0000-000000000000",
        ///               "groupId": "0cb022db-3850-492a-b823-2fe874d66187",
        ///               "sku": "IR0017-2-M",
        ///               "dislikeFeedback": false,
        ///               "dislikeReason": 0,
        ///               "createdAt": null,
        ///               "createdBy": null
        ///             }
        ///           ]
        ///         }
        ///       ],
        ///       "recipient": {
        ///         "name": "BOT",
        ///         "countryCode": "886",
        ///         "mobile": "123456789",
        ///         "country": "Country",
        ///         "zip": "123",
        ///         "city": "City",
        ///         "region": "Region",
        ///         "address": "Address"
        ///       },
        ///       "surveys": [
        ///         {
        ///           "title": "場合",
        ///           "answer": "旅遊"
        ///         }
        ///       ]
        ///     }
        ///
        /// </remarks>
        /// <param name="id">預約單ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}/get")]
        [ProducesResponseType(typeof(GetReservationByIdResponse), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            return Ok(Result<GetReservationByIdResponse>.Success(
                await _mediator.Send(new GetReservationByIdQuery() { Id = id })));

            #region FakeData
            //return Ok(await Task.FromResult(new GetReservationByIdResponse()
            //{
            //    Id = id,
            //    BoxNo = "B202001210123456",
            //    MatchmakerId = Guid.Parse("7A65248E-EFDB-4070-B2C9-5A7EC94290EE"),
            //    SubscribeId = Guid.Parse("A5D9F0A0-46CB-43A7-8F58-2E8DD7AE9D45"),
            //    CustomerId = Guid.Parse("B05125AB-3988-43AF-8F4A-149FB1BAAA7A"),
            //    ItemGroups = new List<ReservationLineItemGroup>()
            //    {
            //        new ReservationLineItemGroup()
            //        {
            //            Id = Guid.Parse("0CB022DB-3850-492A-B823-2FE874D66187"),
            //            SortNum = "1",
            //            Items = new List<ReservationLineItem>()
            //            {
            //                new ReservationLineItem()
            //                {
            //                    Id = Guid.Parse("8A5742A3-445D-4B08-9D14-85D69BC0483F"),
            //                    GroupId = Guid.Parse("0CB022DB-3850-492A-B823-2FE874D66187"),
            //                    Sku = "IR0017-2-M",
            //                    DislikeFeedback = false
            //                }
            //            }
            //        }
            //    },
            //    Recipient = new Recipient()
            //    {
            //        Name = "BOT",
            //        Mobile = "123456789",
            //        CountryCode = "886",
            //        Zip = "123",
            //        Country = "Country",
            //        City = "City",
            //        Region = "Region",
            //        Address = "Address"
            //    },
            //    Surveys = new List<ReservationSurvey>()
            //    {
            //        new ReservationSurvey() { Title = "場合", Answer = "旅遊" }
            //    }
            //}));
            #endregion
        }

        /// <summary>
        /// 預約單清單
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        /// Sample response:
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("query")]
        [ProducesResponseType(typeof(GetReservationResponse), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> Query([FromQuery] GetReservationQuery command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// 新增預約單搭配商品
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        ///
        ///    {
        ///     "id": "8DE8C8F0-F103-4459-A762-255EADE92DB8",
        ///     "groups": [
        ///       {
        ///         "id": "0CB022DB-3850-492A-B823-2FE874D66187",
        ///         "sortNum": 1,
        ///         "items": [
        ///           {
        ///             "position": 1,
        ///             "sku": "IR0032-1-M",
        ///             "source": 2
        ///           },
        ///           {
        ///             "position": 2,
        ///             "sku": "IR0017-2-M",
        ///             "source": 3
        ///           }
        ///         ]
        ///       },
        ///       {
        ///       "id": "D662F00D-54F3-4995-86E3-1582FAD875EA",
        ///         "sortNum": 2,
        ///         "items": [
        ///           {
        ///           "position": 1,
        ///             "sku": "IR0017-2-M",
        ///             "source": 2
        ///           },
        ///           {
        ///           "position": 2,
        ///             "sku": "IR0017-2-M",
        ///             "source": 3
        ///           }
        ///         ]
        ///       },
        ///       {
        ///       "id": "00000000-0000-0000-0000-000000000000",
        ///         "sortNum": 3,
        ///         "items": [
        ///           {
        ///           "position": 1,
        ///             "sku": "IR0032-1-M",
        ///             "source": 2
        ///           },
        ///           {
        ///           "position": 2,
        ///             "sku": "IR0032-1-M",
        ///             "source": 3
        ///           }
        ///         ]
        ///       }
        ///     ]
        ///    }
        /// 
        /// Sample response:
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("group/additem")]
        [SwaggerResponse(200, "搭配師列表", typeof(AddReservationLineItemResponse))]
        [Produces("application/json")]
        public async Task<IActionResult> AddItem([FromBody] AddReservationLineItemCommand command)
        {
            return Ok(Result<AddReservationLineItemResponse>.Success(await _mediator.Send(command)));
        }

        /// <summary>
        /// 更新搭配組合資料
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        ///
        ///    {
        ///    }
        /// 
        /// Sample response:
        /// 
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("group")]
        [SwaggerResponse(200, "更新搭配組合資料", typeof(SubmitReservationGroupResposne))]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateGroupInfo([FromBody] SubmitReservationGroupCommand command)
        {
            return Ok(Result<SubmitReservationGroupResposne>.Success(await _mediator.Send(command)));
        }

        /// <summary>
        /// 更新搭配組合-文案資料
        /// </summary>
        /// <param name="command"></param>
        /// <remarks>
        /// 
        /// Sample request:
        ///
        /// 
        /// Sample response:
        ///
        ///    {}
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("card")]
        [Produces("application/json")]
        [SwaggerResponse(200, "更新搭配組合-文案資料", typeof(SubmitReservationCardResponse))]
        public async Task<IActionResult> UpdateCardInfo([FromBody] SubmitReservationCardCommand command) =>
            Ok(Result<SubmitReservationCardResponse>.Success(await _mediator.Send(command)));

        /// <summary>
        /// 驗證
        /// </summary>
        /// <param name="id">訂閱盒ID</param>
        /// <remarks>
        /// 
        /// Sample request:
        ///
        /// 
        /// Sample response:
        ///
        ///    {}
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/validate")]
        [Produces("application/json")]
        [SwaggerResponse(200, "驗證", typeof(ValudateReservationResponse))]
        public async Task<IActionResult> Validate([FromRoute] Guid id) =>
            Ok(Result<ValudateReservationResponse>.Success(await _mediator.Send(new ValudateReservationCommand(id))));

        [HttpGet]
        [Route("card/message-template")]
        [Produces("application/json")]
        [SwaggerResponse(200, "驗證", typeof(GetCardMessageTemplateResponse))]
        public async Task<IActionResult> GetCardMessageTemplate([FromQuery] int type) =>
            Ok(Result<GetCardMessageTemplateResponse>.Success(await _mediator.Send(new GetCardMessageTemplateQuery() { Type = type })));



        /// <summary>
        /// 新增預約單至訂單
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addorder")]
        [SwaggerResponse(200, "搭配師列表", typeof(AddReservationOrderResponse))]
        [Produces("application/json")]
        public async Task<IActionResult> AddOrder([FromBody] AddReservationOrderCommand command)
        {
            return Ok(Result<AddReservationOrderResponse>.Success(await _mediator.Send(command)));
        }




    }
}
