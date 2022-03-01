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

namespace BoxAdmin.Application.Features.BoxOrders.Queries.GetBoxReservation
{
    //public class GetBoxReservationQuery : IRequest<Result<List<GetBoxReservationResponse>>>
    public class GetBoxReservationQuery : IRequest<List<GetBoxReservationResponse>>
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
        /// 搭配師ID
        /// </summary>
        [SwaggerParameter(Description = "搭配師ID")]
        public string MatchmakerId { get; set; }
    }

    //public class GetBoxReservationQueryHandler : IRequestHandler<GetBoxReservationQuery, Result<List<GetBoxReservationResponse>>>
    public class GetBoxReservationQueryHandler : IRequestHandler<GetBoxReservationQuery, List<GetBoxReservationResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetBoxReservationQueryHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        //public async Task<Result<List<GetBoxReservationResponse>>> Handle(GetBoxReservationQuery command, CancellationToken cancellationToken)
        public async Task<List<GetBoxReservationResponse>> Handle(GetBoxReservationQuery command, CancellationToken cancellationToken)
        {
            List<GetBoxReservationResponse> list = null;

            var queryable = await (from c in _context.Reservations
                                    join s in _context.Subscribes on c.SubscribeId equals s.Id into csGroup
                                    from cs in csGroup.DefaultIfEmpty()
                                    join sp in _context.SubscriptionPlanInfos on cs.SubscriptionPlanId equals sp.Id into csspGroup
                                    from cssp in csspGroup.DefaultIfEmpty()
                                    join rs in _context.ReservationStates on c.State equals rs.Id into crsGroup
                                    from crs in crsGroup.DefaultIfEmpty()
                                    join ci in _context.CustomerInfos on c.CustomerId equals ci.CustomerId into cciGroup
                                    from cci in cciGroup.DefaultIfEmpty()
                                    join mi in _context.MatchmakerInfos on c.MatchmakerId equals mi.Id into cmiGroup
                                    from cmi in cmiGroup.DefaultIfEmpty()
                                    select new
                                    {
                                        BoxNo = c.BoxNo,
                                        DeliveryExpected = c.DeliveryExpected,
                                        StatusName = crs.Title,
                                        MatchmakerId = cmi.Id,
                                        MatchmakerName = cmi.Name,
                                        CustomerId = cci.CustomerId,
                                        SubscriptionPlanName = cssp.Name,
                                        AddPurchaseName = c.AddPurchase ? "是": "否"
                                           
                                    }).ToListAsync(cancellationToken);

            #region 查詢條件

            if (!string.IsNullOrEmpty(command.BoxNo))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.BoxNo == command.BoxNo).ToList();
            }

            if (!string.IsNullOrEmpty(command.CustomerId))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.CustomerId == Guid.Parse(command.CustomerId)).ToList();
            }

            if (!string.IsNullOrEmpty(command.MatchmakerId))
            {
                if (queryable != null)
                    queryable = queryable.Where(x => x.MatchmakerId == Guid.Parse(command.MatchmakerId)).ToList();
            }
            #endregion

            if (queryable != null)
            {

                list = queryable.Select(x => new GetBoxReservationResponse
                {
                    BoxNo = x.BoxNo,
                    DeliveryExpected = x.DeliveryExpected?.ToString("yyyy/MM.dd"),
                    StatusName = x.StatusName,
                    MatchmakerName = x.MatchmakerName,
                    CustomerId = x.CustomerId,
                    SubscriptionPlanName = x.SubscriptionPlanName,
                    AddPurchaseName = x.AddPurchaseName

                }).ToList();
            }
          
            return await Task.FromResult(list);
        }
    }

}
