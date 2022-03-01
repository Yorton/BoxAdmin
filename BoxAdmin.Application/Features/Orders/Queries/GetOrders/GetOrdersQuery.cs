using AutoMapper;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Framework.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Orders.Queries.GetOrders
{
    /// <summary>
    /// 時間篩選
    /// </summary>
    public enum TimeFilter
    {
        到貨時間 = 1,
        付款時間 = 2,
        鑑賞期 = 3,
        成立時間 = 4,
    }

    public enum OrderType
    {
        直購 = 1,
        Box = 2,
        訂閱服務 = 3,
    }

    public class GetOrdersQuery : IRequest<Result<List<GetOrdersResponse>>>
    {
        /// <summary>
        /// 訂單類型
        /// </summary>
        [SwaggerParameter(Description = "訂單類型")]
        public int OrderType { get; set; } = -1;

        /// <summary>
        /// 購物訂單編號
        /// </summary>
        [SwaggerParameter(Description = "購物訂單編號")]
        public string TransactionNo { get; set; }

        /// <summary>
        /// 會員ID
        /// </summary>
        [SwaggerParameter(Description = "會員ID")]
        public string CustomerId { get; set; }

        /// <summary>
        /// 會員姓名
        /// </summary>
        [SwaggerParameter(Description = "會員姓名")]
        public string CustomerName { get; set; }

        /// <summary>
        /// 時間篩選
        /// </summary>
        [SwaggerParameter(Description = "時間篩選")]
        public int TimeFilter { get; set; }

        /// <summary>
        /// 時間篩選起日
        /// </summary>
        [SwaggerParameter(Description = "時間篩選起日")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 時間篩選訖日
        /// </summary>
        [SwaggerParameter(Description = "時間篩選訖日")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        [SwaggerParameter(Description = "狀態")]
        public int OrderState { get; set; } = -1;
    }

    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Result<List<GetOrdersResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetOrdersQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<List<GetOrdersResponse>>> Handle(GetOrdersQuery command, CancellationToken cancellationToken)
        {
            List<GetOrdersResponse> list = null;

            try
            {
                var queryable = await (from o in _context.Orders
                                       join c in _context.CustomerInfos on o.CustomerId equals c.CustomerId into g1
                                       from c in g1.DefaultIfEmpty()
                                       join s in _context.OrderStates on o.OrderState equals s.Id into g2
                                       from s in g2.DefaultIfEmpty()
                                       select new { 
                                           TransactionNo = o.TransactionNo,
                                           CustomerId = o.CustomerId,
                                           CustomerName = c.Name,
                                           OrderType = o.OrderType,
                                           OrderTypeName = ((OrderType)o.OrderType).ToString(),
                                           OrderTime = o.OrderTime,
                                           CreateTime = o.CreateTime,
                                           OrderState = o.OrderState,
                                           OrderStateName = s.Title
                                           // DevileryTime =
                                           // AppreciationTime =
                                       }).ToListAsync(cancellationToken);

                #region 查詢條件

                if (command.OrderType > 0)
                {
                    if (queryable != null)
                        queryable = queryable.Where(x => x.OrderType == command.OrderType).ToList();
                }

                if (!string.IsNullOrEmpty(command.TransactionNo))
                {
                    if (queryable != null)
                        queryable = queryable.Where(x => x.TransactionNo == string.Format("{0,-16}", command.TransactionNo)).ToList();
                }

                if (!string.IsNullOrEmpty(command.CustomerId))
                {
                    if (queryable != null)
                        queryable = queryable.Where(x => x.CustomerId == Guid.Parse(command.CustomerId)).ToList();
                }

                if (!string.IsNullOrEmpty(command.CustomerName))
                {
                    if (queryable != null)
                        queryable = queryable.Where(x => !string.IsNullOrEmpty(x.CustomerName)
                                                         ? x.CustomerName.Contains(command.CustomerName) : false).ToList();
                }

                if (command.TimeFilter > 0 && (command.StartDate != null || command.EndDate != null))
                {
                    if (queryable != null)
                    { 
                        switch (command.TimeFilter)
                        {
                            case (int)TimeFilter.到貨時間:
                                if (command.StartDate != null)
                                {
                                }
                                if (command.EndDate != null)
                                { 
                                }
                                break;
                            case (int)TimeFilter.付款時間:
                                if (command.StartDate != null)
                                {
                                    queryable = queryable.Where(x => x.OrderTime >= command.StartDate.Value).ToList();
                                }
                                if (command.EndDate != null)
                                {
                                    queryable = queryable.Where(x => x.OrderTime < command.EndDate.Value.AddDays(1)).ToList();
                                }
                                break;
                            case (int)TimeFilter.鑑賞期:
                                break;
                            case (int)TimeFilter.成立時間:
                                if (command.StartDate != null)
                                {
                                    queryable = queryable.Where(x => x.CreateTime >= command.StartDate.Value).ToList();
                                }
                                if (command.EndDate != null)
                                {
                                    queryable = queryable.Where(x => x.CreateTime < command.EndDate.Value.AddDays(1)).ToList();
                                }
                                break;
                        }
                    }
                }

                if (command.OrderState > -1)
                {
                    if (queryable != null)
                        queryable = queryable.Where(x => x.OrderState == command.OrderState).ToList();
                }

                #endregion

                if (queryable != null)
                {
                    list = queryable.Select(x => new GetOrdersResponse
                    {
                        TransactionNo = x.TransactionNo,
                        CustomerId = x.CustomerId,
                        CustomerName = x.CustomerName,
                        OrderType = x.OrderType,
                        OrderTypeName = x.OrderTypeName,
                        OrderTime = x.OrderTime,
                        CreateTime = x.CreateTime,
                        OrderState = x.OrderState,
                        OrderStateName = x.OrderStateName,
                        // DevileryTime =
                        // AppreciationTime =
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return Result<List<GetOrdersResponse>>.Fail(ex.Message);
            }

            return Result<List<GetOrdersResponse>>.Success(list);
        }

        
    }
}
