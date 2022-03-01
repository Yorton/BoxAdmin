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

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxOrders
{
    /// <summary>
    /// 時間篩選
    /// </summary>
    public enum TimeFilter
    {
        期望配送時間 = 1,
        最後表態時間 = 2,
        出貨時間 = 3,
        配達時間 = 4,
        試穿最後期限 = 5
    }


    //public class GetBoxOrdersQuery : IRequest<Result<List<GetBoxOrdersResponse>>>
    public class GetBoxOrdersQuery : IRequest<List<GetBoxOrdersResponse>>
    {
        /// <summary>
        /// BOX訂閱盒編號
        /// </summary>
        [SwaggerParameter(Description = "BOX訂閱盒編號")]
        public string BoxNo { get; set; }

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
        /// 搭配師ID
        /// </summary>
        [SwaggerParameter(Description = "搭配師ID")]
        public string MatchmakerId { get; set; }


        /// <summary>
        /// 時間篩選
        /// </summary>
        [SwaggerParameter(Description = "時間篩選")]
        public int TimeFilter { get; set; }

        /// <summary>
        /// 期望配送日期
        /// </summary>
        [SwaggerParameter(Description = "期望配送日期")]
        public string DeliveryExpected { get; set; }

        //是否表態

        /// <summary>
        /// 狀態ID
        /// </summary>
        [SwaggerParameter(Description = "狀態ID")]
        public int StatusId { get; set; }

    }

    //public class GetBoxOrdersQueryHandler : IRequestHandler<GetBoxOrdersQuery, Result<List<GetBoxOrdersResponse>>>
    public class GetBoxOrdersQueryHandler : IRequestHandler<GetBoxOrdersQuery, List<GetBoxOrdersResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetBoxOrdersQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<List<GetBoxOrdersResponse>>> Handle(GetBoxOrdersQuery command, CancellationToken cancellationToken)
        public async Task<List<GetBoxOrdersResponse>> Handle(GetBoxOrdersQuery command, CancellationToken cancellationToken)
        {
            List<GetBoxOrdersResponse> list = null;

            var queryable = await (from c in _context.Reservations
                                    join s in _context.Subscribes on c.SubscribeId equals s.Id into csGroup
                                    from cs in csGroup.DefaultIfEmpty()
                                    join rs in _context.ReservationStates on c.State equals rs.Id into crsGroup
                                    from crs in crsGroup.DefaultIfEmpty()
                                    join ci in _context.CustomerInfos on c.CustomerId equals ci.CustomerId into cciGroup
                                    from cci in cciGroup.DefaultIfEmpty()
                                    join mi in _context.MatchmakerInfos on c.MatchmakerId equals mi.Id into cmiGroup
                                    from cmi in cmiGroup.DefaultIfEmpty()
                                    select new {
                                        Id = c.Id,
                                        BoxNo = c.BoxNo,
                                        CustomerId = cci.CustomerId,
                                        CustomerName = cci.Name,
                                        MatchmakerId = cmi.Id,
                                        MatchmakerName = "",//cmi.Name,
                                        DeliveryExpected = c.DeliveryExpected,
                                        StatusId = crs.Id,
                                        StatusName = crs.Title 
                                    }).ToListAsync(cancellationToken);

            #region 查詢條件

            if (!string.IsNullOrEmpty(command.BoxNo))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.BoxNo == command.BoxNo).ToList();
            }

            if (!string.IsNullOrEmpty(command.CustomerId)/*command.CustomerId != Guid.Empty*/)
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

            if (command.TimeFilter > 0)
            {
                switch (command.TimeFilter)
                {
                    case (int)TimeFilter.期望配送時間:
                        if (queryable != null && !string.IsNullOrEmpty(command.DeliveryExpected)) 
                        {
                            queryable = queryable.Where(x => x.DeliveryExpected
                                                            == DateTime.Parse($"{command.DeliveryExpected:yyyy-MM-dd}")
                                                            ).ToList();
                        }
                        break;
                    case (int)TimeFilter.最後表態時間:
                        break;
                    case (int)TimeFilter.出貨時間:
                        break;
                    case (int)TimeFilter.配達時間:
                        break;
                    case (int)TimeFilter.試穿最後期限:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(command.MatchmakerId)/*command.MatchmakerId != Guid.Empty*/)
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.MatchmakerId == Guid.Parse(command.MatchmakerId)).ToList();
            }

            //是否表態

            if (command.StatusId != 0) //等待預約=-1, 其他狀態均 > 0
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.StatusId == command.StatusId).ToList();
            }
            #endregion

            if (queryable != null)
            {
                list = queryable.Select(x => new GetBoxOrdersResponse
                {
                    Id = x.Id.ToString(),
                    BoxNo = x.BoxNo,
                    CustomerId = x.CustomerId,
                    CustomerName = x.CustomerName,
                    MatchmakerId = x.MatchmakerId,
                    MatchmakerName = x.MatchmakerName,
                    DeliveryExpected = x.DeliveryExpected?.ToString("yyyy/MM/dd"),
                    StatusId = x.StatusId,
                    StatusName = x.StatusName

                }).ToList();
            }
          
            return await Task.FromResult(list);
        }
    }



}
