using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using Swashbuckle.AspNetCore.Annotations;
using AutoMapper;
using MediatR;

using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;
using BoxAdmin.Application.DTOs.Settings;
using System.Threading;


namespace BoxAdmin.Application.Features.BoxService.Queries.GetSubscribeList
{
    /// <summary>
    /// 時間篩選
    /// </summary>
    public enum TimeFilter
    {
        訂閱完成時間 = 1,
        服務結束時間 = 2,
        申請暫停時間 = 3
    }

    //public class GetSubscribeListQuery : IRequest<Result<List<GetSubscribeListResponse>>>
    public class GetSubscribeListQuery : IRequest<List<GetSubscribeListResponse>>
    {
        /// <summary>
        /// 服務訂單編號
        /// </summary>
        [SwaggerParameter(Description = "服務訂單編號")]
        public string SubscribeNo { get; set; }

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
        /// 申請暫停
        /// </summary>
        [SwaggerParameter(Description = "申請暫停")]
        public int Suspend { get; set; }

        /// <summary>
        /// 時間篩選
        /// </summary>
        [SwaggerParameter(Description = "時間篩選")]
        public int TimeFilter { get; set; }

        /// <summary>
        /// 訂閱結束時間
        /// </summary>
        [SwaggerParameter(Description = "訂閱結束時間")]
        public string DueTime { get; set; }

        /// <summary>
        /// 訂閱狀態ID
        /// </summary>
        [SwaggerParameter(Description = "訂閱狀態ID")]
        public int SubscribeStatusId { get; set; }

        /// <summary>
        /// 成立方式
        /// </summary>
        [SwaggerParameter(Description = "成立方式")]
        public int CreatedMethod { get; set; }

    }

    //public class GetSubscribeListQueryHandler : IRequestHandler<GetSubscribeListQuery, Result<List<GetSubscribeListResponse>>>
    public class GetSubscribeListQueryHandler : IRequestHandler<GetSubscribeListQuery, List<GetSubscribeListResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetSubscribeListQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<List<GetSubscribeListResponse>>> Handle(GetSubscribeListQuery command, CancellationToken cancellationToken)
        public async Task<List<GetSubscribeListResponse>> Handle(GetSubscribeListQuery command, CancellationToken cancellationToken)
        {
            List<GetSubscribeListResponse> list = null;

            var queryable = await (from s in _context.Subscribes
                                    join sp in _context.SubscriptionPlanInfos on s.SubscriptionPlanId equals sp.Id 
                                    join ss in _context.SubscribeStates on s.State equals ss.Id 
                                    join ci in _context.CustomerInfos on s.CustomerId equals ci.CustomerId into sciGroup
                                    from sci in sciGroup.DefaultIfEmpty()
                                    select new
                                    {
                                        Id = s.Id,
                                        SubscribeNo = s.SubscribeNo,
                                        CustomerId = sci.CustomerId,
                                        CustomerName = sci.Name,
                                        PurchasePlan = sp.Type == 1 ? "季"
                                                                    : sp.Type == 2 ? "月"
                                                                    : sp.Type == 3 ? "年" : "", 
                                        //成立方式, 
                                        CreatedMethod = s.AutoRenew == false ? "會員下單" : "自動續約",
                                        
                                        //Box已啟用數, 
                                        BoxEnalbedCount = _context.Reservations.Where(x => x.SubscribeId == s.Id
                                                            && x.CustomerId == s.CustomerId
                                                            && x.State != -1).Count().ToString()//非等待預約
                                                            + "/"+
                                                            _context.Reservations.Where(x => x.SubscribeId == s.Id 
                                                            && x.CustomerId == s.CustomerId).Count().ToString(),

                                        //申請暫停
                                        SubscribeStatusId = ss.Id,
                                        SubscribeStatus = ss.Title,
                                        DueTime = s.DueDate
                                    }).ToListAsync(cancellationToken);

            #region 查詢條件

            if (!string.IsNullOrEmpty(command.SubscribeNo))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.SubscribeNo == command.SubscribeNo).ToList();
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

            if (command.Suspend > 0) //申請暫停
            {}


            if (command.TimeFilter > 0)
            {
                switch (command.TimeFilter)
                {
                    case (int)TimeFilter.訂閱完成時間:
                        if (queryable != null && !string.IsNullOrEmpty(command.DueTime))
                        {
                            queryable = queryable.Where(x => x.DueTime
                                                            == DateTime.Parse($"{command.DueTime:yyyy-MM-dd}")
                                                            ).ToList();
                        }
                        break;
                    case (int)TimeFilter.服務結束時間:
                        break;
                    case (int)TimeFilter.申請暫停時間:
                        break;
                }
            }

            if (command.SubscribeStatusId > 0)
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.SubscribeStatusId == command.SubscribeStatusId).ToList();
            }

            if (command.CreatedMethod >= 0) //成立方式
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.CreatedMethod == (command.CreatedMethod == 0 ? "會員下單" : "自動續約")).ToList();
            }
            #endregion

            if (queryable != null)
            {
                list = queryable.Select(x => new GetSubscribeListResponse
                {
                    Id = x.Id,
                    SubscribeNo = x.SubscribeNo,
                    CustomerId = x.CustomerId,
                    CustomerName = x.CustomerName,
                    PurchasePlan = x.PurchasePlan,

                    CreatedMethod = x.CreatedMethod,
                    BoxEnalbedCount = x.BoxEnalbedCount, 
                    
                    //申請暫停

                    SubscribeStatusId = x.SubscribeStatusId,
                    SubscribeStatus = x.SubscribeStatus,
                    DueTime = x.DueTime.ToString("yyyy/MM/dd")

                }).ToList();
            }
      
            return await Task.FromResult(list);

        }
    }

}
