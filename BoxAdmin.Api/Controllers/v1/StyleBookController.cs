using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBooks;
using BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBookById;
using BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBookConditions;
using BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookSubmit;
using BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookImageSubmit;
using BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookDelete;
using BoxAdmin.Application.Features.StyleBooks.Queries.GetProductByTag;
using BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookExport;
using BoxAdmin.Application.Interfaces.Shared;
using System.Net;

namespace BoxAdmin.Api.Controllers.v1
{
    [Authorize]
    public class StyleBookController : BaseApiController
    {
        private readonly IBoxExportService _iBoxExportService;

        public StyleBookController(IBoxExportService iBoxExportService)
        {
            _iBoxExportService = iBoxExportService;
        }

        /// <summary>
        /// StyleBook清單
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/stylebook/query
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("query")]
        [Produces("application/json")]
        [SwaggerResponse(200, "StyleBook清單", typeof(GetStyleBooksResponse))]
        public async Task<IActionResult> GetAll([FromQuery] GetStyleBooksQuery command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// StyleBook資料
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/stylebook/info
        ///     
        /// Sample response:
        /// 
        /// </remarks>
        /// <returns></returns>
        /// <param name="id">StyleBook Id</param>
        [HttpGet]
        [Route("{id}/info")]
        [Produces("application/json")]
        [SwaggerResponse(200, "StyleBook資料", typeof(GetStyleBookByIdResponse))]
        public async Task<IActionResult> GetInfo([FromRoute] Guid id) =>
            Ok(Result<GetStyleBookByIdResponse>.Success(await _mediator.Send(new GetStyleBookByIdQuery() { Id = id })));

        /// <summary>
        /// 新增或更新StyleBook
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/v1/stylebook/submit
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
        [SwaggerResponse(200, "新增或更新StyleBook", typeof(StyleBookSubmitResponse))]
        public async Task<IActionResult> Submit(StyleBookSubmitCommand command)
        {
            return Ok(Result<StyleBookSubmitResponse>.Success(await _mediator.Send(command)));
        }

        /// <summary>
        /// 上傳StyleBook圖片
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        /// Sample Resposne:
        /// 
        ///     {
        ///         imageUrl: "https://xxxxxx.s3-ap-northeast-1.amazonaws.com/Box_Images/stylebook/xxxxx-xxxxxxx-xxxxxxx-xxxxx/xxxxx-xxxxxxx-xxxxxxx-xxxxx.jpg"
        ///     }
        /// 
        /// </remarks>
        /// <param name="file"></param>
        /// <param name="id">StyleBook ID</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/image")]
        public async Task<IActionResult> SaveImage([FromForm] IFormFile file, [FromRoute] Guid id)
        {
            using var stream = new System.IO.MemoryStream();
            await file.CopyToAsync(stream);

            var response = await _mediator.Send(new StyleBookImageSubmitCommand(id, stream, file.FileName));
            return Ok(Result<StyleBookImageSubmitResponse>.Success(response));
        }

        /// <summary>
        /// 風格分類
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("style-list")]
        [SwaggerResponse(200, "風格分類", typeof(GetStyleBookConditionsQuery))]
        public async Task<IActionResult> GetStyleList()
        {

            return Ok(await _mediator.Send(new GetStyleBookConditionsQuery() { Type = 1 }));
        }

        /// <summary>
        /// 情境場合
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("occasion-list")]
        [SwaggerResponse(200, "情境場合", typeof(GetStyleBookConditionsQuery))]
        public async Task<IActionResult> GetOccasion()
        {
            return Ok(await _mediator.Send(new GetStyleBookConditionsQuery() { Type = 2 }));
        }

        /// <summary>
        /// 刪除StyleBook
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/remove")]
        [Produces("application/json")]
        [SwaggerResponse(200, "刪除StyleBook", typeof(StyleBookDeleteResponse))]
        public async Task<IActionResult> DeleteStyleBook([FromRoute] Guid id)
        {
            return Ok(await _mediator.Send(new StyleBookDeleteCommand() { Id = id }));
        }

        /// <summary>
        /// 以標籤查詢商品資料
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("product/filter-by-tag")]
        [Produces("application/json")]
        [SwaggerResponse(200, "以標籤查詢商品資料", typeof(GetProductByTagResponse))]
        public async Task<IActionResult> GetProductByTag([FromQuery] GetProductByTagQuery command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// 匯出StyleBook資料
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("product/export")]
        [Produces("application/json")]
        [SwaggerResponse(200, "匯出StyleBook資料", typeof(StyleBookExportResponse))]
        public async Task<IActionResult> ExportExcel([FromForm] StyleBookExportCommand command)
        {
            var list = await _mediator.Send(command);
            var downloadPath = _iBoxExportService.ExportStyleBookList(list);

            return Ok(new StyleBookExportResponse { DownloadPath = downloadPath });
        }
    }
}
