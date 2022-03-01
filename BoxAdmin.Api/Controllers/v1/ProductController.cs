using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Api.Controllers.v1
{
    using BoxAdmin.Framework.Results;
    using BoxAdmin.Application.Features.Products.Commands.CreateProduct;
    using BoxAdmin.Application.Features.Products.Commands.CreateProductImage;
    using BoxAdmin.Application.Features.Products.Commands.CreateProductTag;
    using BoxAdmin.Application.Features.Products.Queries.GetProductById;
    using BoxAdmin.Application.Features.Products.Queries.GetProductByFavorites;
    using BoxAdmin.Application.Features.Products.Queries.GetProductByScore;
    using BoxAdmin.Application.Features.Products.Queries.GetProductBySeriesNo;
    using BoxAdmin.Application.Features.Products.Queries.GetProductByStylebookFilter;
    using BoxAdmin.Application.Features.Products.Queries.GetProductByRecommand;

    [Authorize]
    public class ProductController : BaseApiController
    {
        /// <summary>
        /// 商品主檔資料
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("series/{id}/info")]
        [Produces("application/json")]
        [SwaggerResponse(200, "商品主檔資料", typeof(GetProductByIdResponse))]
        public async Task<IActionResult> GetInfo([FromRoute] string id)
        {
            return Ok(Result<GetProductByIdResponse>.Success(
                await _mediator.Send(new GetProductByIdQuery() { SeriesNo = id })));
        }

        /// <summary>
        /// 商品資料匯入
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        /// Sample response:
        /// 
        ///     {
        ///     
        ///     }
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("series/import")]
        [Produces("application/json")]
        [SwaggerResponse(200, "商品資料匯入", typeof(CreateProductResponse))]
        public async Task<IActionResult> Import(CreateProductCommand command)
        {
            return Ok(Result<CreateProductResponse>.Success(await _mediator.Send(command)));
        }

        /// <summary>
        /// 商品圖資料匯入
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        /// Sample response:
        /// 
        ///     {
        ///     
        ///     }
        ///     
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Route("images/import")]
        [Produces("application/json")]
        [SwaggerResponse(200, "商品圖資料匯入", typeof(CreateProductImageResponse))]
        public async Task<IActionResult> ImportImage(CreateProductImageCommand command)
        {
            return Ok(Result<CreateProductImageResponse>.Success(await _mediator.Send(command)));
        }

        /// <summary>
        /// 商品標籤匯入
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        /// Sample response:
        /// 
        ///     {
        ///     
        ///     }
        ///     
        /// </remarks>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("tag/import")]
        [Produces("application/json")]
        [SwaggerResponse(200, "商品標籤匯入", typeof(CreateProductTagResponse))]
        public async Task<IActionResult> ImportTagToSeries(CreateProductTagCommand command)
        {
            return Ok(Result<CreateProductTagResponse>.Success(await _mediator.Send(command)));
        }

        /// <summary>
        /// 收藏清單
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///      GET /api/v{version}/product/items/xxxxxxx-xxxxxxx-xxxxxxx-xxxx/favorites
        ///      
        /// Sample response:
        /// 
        ///      {
        ///          "data": {
        ///              "id": "2d782a35-3f0d-453b-84e8-245c157b0eb6",
        ///              "items": [{
        ///                      "sku": "IR0044-1-XS",
        ///                      "series": "IR0044",
        ///                      "image": "https://obcdn4.obdesign.com.tw/catalog/products/IR0044/IR0044@CB-1-1.jpg",
        ///                      "name": "側邊拼接皮革美腿窄管褲(2色)",
        ///                      "price": "419",
        ///                      "color": "黑色",
        ///                      "size": "XS",
        ///                      "weight": 0.329,
        ///                      "stock": 11,
        ///                      "preStock": 0
        ///      
        ///                  },
        ///                  {
        ///                      "sku": "IR0044-2-L",
        ///                      "series": "IR0044",
        ///                      "image": "https://obcdn4.obdesign.com.tw/catalog/products/IR0044/IR0044@CB-2-1.jpg",
        ///                      "name": "側邊拼接皮革美腿窄管褲(2色)",
        ///                      "price": "419",
        ///                      "color": "深灰",
        ///                      "size": "L",
        ///                      "weight": 0.379,
        ///                      "stock": 5,
        ///                      "preStock": 0
        ///                  }
        ///              ]
        ///          },
        ///          "failed": false,
        ///          "message": null,
        ///          "succeeded": true
        ///      }
        /// 
        /// </remarks>
        /// <param name="id">會員ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("items/{id}/favorites")]
        [ProducesResponseType(typeof(GetProductByFavoritesResponse), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductByFavorites([FromRoute] Guid id)
        {
            return Ok(Result<GetProductByFavoritesResponse>.Success(
                await _mediator.Send(new GetProductByFavoritesQuery() { Id = id })));
        }

        /// <summary>
        /// 猜你喜歡
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///      GET /api/v{version}/product/items/xxxxxxx-xxxxxxx-xxxxxxx-xxxx/score
        ///      
        /// Sample response:
        /// 
        ///      {
        ///          "data": {
        ///              "id": "2d782a35-300d-453e-84e8-245c157b0eb5",
        ///              "items": [{
        ///                      "sku": "IR0120-1-36",
        ///                      "series": "IR0120",
        ///                      "image": "https://obcdn4.obdesign.com.tw/catalog/products/IR0120/IR0120@CB-1-1.jpg",
        ///                      "name": "方釦麂皮粗跟短靴",
        ///                      "price": "3680",
        ///                      "color": "黑",
        ///                      "size": "36",
        ///                      "weight": 1.418,
        ///                      "stock": 1,
        ///                      "preStock": 0
        ///                  },
        ///                  {
        ///                      "sku": "IR0138-2-S",
        ///                      "series": "IR0138",
        ///                      "image": "https://obcdn4.obdesign.com.tw/catalog/products/IR0138/IR0138@CB-2-1.jpg",
        ///                      "name": "【婚禮系列】荷葉滾邊條紋襯衫假兩件洋裝",
        ///                      "price": "1280",
        ///                      "color": "紅",
        ///                      "size": "S",
        ///                      "weight": 0.467,
        ///                      "stock": 3,
        ///                      "preStock": 0
        ///                  }
        ///              ]
        ///          },
        ///          "failed": false,
        ///          "message": null,
        ///          "succeeded": true
        ///      }
        /// 
        /// </remarks>
        /// <param name="id">會員ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("items/{id}/score")]
        [ProducesResponseType(typeof(GetProductByScoreResponse), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductByScore([FromRoute] Guid id)
        {
            return Ok(Result<GetProductByScoreResponse>.Success(
                await _mediator.Send(new GetProductByScoreQuery() { Id = id })));
        }

        /// <summary>
        /// 商品搜尋結果(BY商品貨號)
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///      GET /api/v{version}/product/items/AA1234/byseries
        ///      
        /// Sample response:
        /// 
        /// 
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("items/{id}/byseries")]
        [ProducesResponseType(typeof(GetProductBySeriesNoResponse), 200)]
        [SwaggerResponse(200, "商品搜尋結果", typeof(GetProductBySeriesNoResponse))]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductBySeriesNo([FromRoute] string id)
        {
            return Ok(Result<GetProductBySeriesNoResponse>.Success(
                await _mediator.Send(new GetProductBySeriesNoQuery() { SeriesNo = id })));
        }

        /// <summary>
        /// 商品搜尋結果(ByStyleBook搭配商品)
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///      GET /api/v{version}/product/items/bystylebookfilter
        ///      
        /// Sample response:
        /// 
        ///      {
        ///          "items": []
        ///      }
        /// 
        /// </remarks>
        /// <param name="seriesNo">款號</param>
        /// <param name="color">顏色</param>
        /// <returns></returns>
        [HttpGet]
        [Route("items/bystylebookfilter")]
        [SwaggerResponse(200, "商品搜尋結果(ByStyleBook搭配商品)", typeof(GetProductByStylebookFilterResponse))]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductByStylebookFilter([FromQuery] string seriesNo, string color)
        {
            return Ok(Result<GetProductByStylebookFilterResponse>.Success(
                await _mediator.Send(new GetProductByStylebookFilterQuery() { Series = seriesNo, Color = color })));
        }

        /// <summary>
        /// 系統推薦商品清單
        /// </summary>
        /// <remarks>
        /// 
        /// Sample request:
        /// 
        ///      GET /api/v{version}/product/items/recommand
        ///      
        /// Sample response:
        /// 
        ///      {
        ///          "data": {
        ///              "items": [{
        ///                      "sku": "IR0044-1-XS",
        ///                      "series": "IR0044",
        ///                      "image": "https://obcdn4.obdesign.com.tw/catalog/products/IR0044/IR0044@CB-1-1.jpg",
        ///                      "name": "側邊拼接皮革美腿窄管褲(2色)",
        ///                      "price": "419",
        ///                      "color": "黑色",
        ///                      "size": "XS",
        ///                      "weight": 0.329,
        ///                      "stock": 11,
        ///                      "preStock": 0
        ///      
        ///                  }
        ///              ]
        ///          },
        ///          "failed": false,
        ///          "message": null,
        ///          "succeeded": true
        ///      }
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("items/recommand")]
        [ProducesResponseType(typeof(GetProductByRecommandResponse), 200)]
        [Produces("application/json")]
        public async Task<IActionResult> GetProductBySystemRecommand()
        {
            return Ok(Result<GetProductByRecommandResponse>.Success(await _mediator.Send(new GetProductByRecommandQuery())));
        }
    }
}
