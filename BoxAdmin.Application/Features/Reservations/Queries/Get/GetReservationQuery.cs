using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;
using BoxAdmin.Framework.Results;
using BoxAdmin.Application.Interfaces.Contexts;

namespace BoxAdmin.Application.Features.Reservations.Queries.Get
{
    public class GetReservationQuery : IRequest<Result<GetReservationResponse>>
    {
        /// <summary>
        /// BOX預約單編號
        /// </summary>
        public string? BoxNo { get; set; }

        /// <summary>
        /// 會員ID
        /// </summary>
        public Guid? CustomerId { get; set; }

        public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, Result<GetReservationResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IBoxDbContext _context;

            public GetReservationQueryHandler(IMapper mapper, IBoxDbContext context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<GetReservationResponse>> Handle(GetReservationQuery command, CancellationToken cancellationToken)
            {
                List<ReservationItem> result = null;
                try
                {
                    var hadCustomerId = command.CustomerId != null && command.CustomerId.HasValue && command.CustomerId.Value != new Guid();

                    var queryable = _context.Reservations.AsQueryable();
                    
                    if (!string.IsNullOrEmpty(command.BoxNo))
                    {
                        queryable = queryable.Where(w => w.BoxNo == command.BoxNo);
                    }
                    
                    if (hadCustomerId)
                    {
                        queryable = queryable.Where(w => w.CustomerId == command.CustomerId.Value);
                    }
                    
                    var getDatas = await queryable
                        //.Include(s => s.ReservationLineItemGroups)
                        //.Include(s => s.ReservationLineItems)
                        //.Include(s => s.ReservationRecipient)
                        //.Include(s => s.ReservationCustomer)
                        //.Include(s => s.CardDesigns)
                        .ToListAsync(cancellationToken: cancellationToken);
                    
                    if (getDatas != null && getDatas.Count > 0)
                    {
                        result = _mapper.Map<List<ReservationItem>>(getDatas);
                        foreach (var item in result)
                        {
                            if (item.SubscribeId != new Guid())
                            {
                                var SubscriptionPlanId = _context.Subscribes.Where(w => w.Id == item.SubscribeId).Select(s => s.SubscriptionPlanId).SingleOrDefault();
                                if (SubscriptionPlanId > 0)
                                {
                                    item.SubscribeName = _context.SubscriptionPlanInfos.Where(w => w.Id == SubscriptionPlanId).Select(s => s.Name).SingleOrDefault();
                                }
                            }                            
                            item.MatchmakerName = _context.MatchmakerInfos.Where(w => w.Id == item.MatchmakerId).Select(s => s.Name).SingleOrDefault();
                            item.StateTitle = _context.ReservationStates.Where(w => w.Id == item.State).Select(s => s.Title).SingleOrDefault();
                        }
                        if (result != null && result.Count > 0)
                        {
                            
                        }
                    }
                    return Result<GetReservationResponse>.Success(new GetReservationResponse() { Items = result });
                }
                catch (Exception ex)
                {
                    return Result<GetReservationResponse>.Fail(ex.Message);
                }
            }
        }
    }
}
