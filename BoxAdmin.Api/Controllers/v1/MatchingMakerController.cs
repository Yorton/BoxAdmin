using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Api.Controllers.v1
{
    using BoxAdmin.Framework.Results;
    using BoxAdmin.Application.Features.MatchingMakers.Queries.GetMatchingMakers;
    using BoxAdmin.Application.Features.MatchingMakers.Queries.GetMatchingMakerById;
    using BoxAdmin.Application.Features.MatchingMakers.Commands.MatchingMakerSubmit;
    using BoxAdmin.Application.Features.MatchingMakers.Commands.MatchingMakerImageSubmit;

    //[Authorize]
    public class MatchingMakerController : BaseApiController
    {
        [HttpGet]
        [Route("query")]
        [Produces("application/json")]
        [SwaggerResponse(200, "搭配師列表", typeof(GetMatchingMakersResponse))]
        public async Task<IActionResult> GetAll([FromQuery] GetMatchingMakersQuery command)
        {
            return Ok(Result<GetMatchingMakersResponse>.Success(await _mediator.Send(command)));
        }

        [HttpGet]
        [Route("get")]
        [Produces("application/json")]
        [SwaggerResponse(200, "搭配師資料", typeof(GetMatchingMakerByIdResponse))]
        public async Task<IActionResult> GetById([FromQuery] Guid id)
        {
            return Ok(Result<GetMatchingMakerByIdResponse>.Success(await _mediator.Send(new GetMatchingMakerByIdQuery(id))));
        }

        [HttpPost]
        [Route("submit")]
        [Produces("application/json")]
        [SwaggerResponse(200, "新增編輯", typeof(GetMatchingMakerByIdResponse))]
        public async Task<IActionResult> Submit(MatchingMakerSubmitCommand command)
        {
            var submit = await _mediator.Send(command);
            return Ok(Result<GetMatchingMakerByIdResponse>.Success(await _mediator.Send(new GetMatchingMakerByIdQuery(submit.Id))));
        }

        [HttpPost]
        [Route("{id}/image")]
        public async Task<IActionResult> SaveImage([FromRoute] Guid id, [FromForm] IFormFile[] file, [FromForm] int type)
        {
            var command = new MatchingMakerImageSubmitCommand(id, type, file);

            var responseObject = await _mediator.Send(command);

            return Ok(Result<MatchingMakerImageSubmitResponse>.Success(responseObject));
        }
    }
}
