using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace BoxAdmin.Application.Features.Reservations.Commands.SubmitReservationGroup
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;

    public class SubmitReservationGroupCommand : IRequest<SubmitReservationGroupResposne>
    {
        public List<SubmitReservationGroupCommandItem> Items { get; set; }
    }

    public class SubmitReservationGroupCommandItem
    {
        public Guid Id { get; set; }
        public Guid? StyleId { get; set; }
        public Guid? OccasionId { get; set; }
    }

    public class StyleBookImageSubmitHandler : IRequestHandler<SubmitReservationGroupCommand, SubmitReservationGroupResposne>
    {
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public StyleBookImageSubmitHandler(
            IBoxDbContext context,
            IAuthenticatedUserService authenticatedUserService)
        {
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<SubmitReservationGroupResposne> Handle(SubmitReservationGroupCommand command, CancellationToken cancellationToken)
        {
            foreach (var item in command.Items)
            {
                var id = item.Id;
                var styleId = item.StyleId ?? throw new ArgumentException("未輸入風格ID");
                var occasionId = item.OccasionId ?? throw new ArgumentException("未輸入場合ID");

                var reservationGroupQuery = await _context.ReservationLineItemGroups.SingleOrDefaultAsync(x => x.Id == id, cancellationToken)
                    ?? throw new ArgumentException("查無資料");

                var styleQuery = await _context.StyleBookConditions.SingleOrDefaultAsync(x => x.Type == 1 && x.Id == styleId)
                    ?? throw new ArgumentException("查無風格資料");

                var occasionQuery = await _context.StyleBookConditions.SingleOrDefaultAsync(x => x.Type == 2 && x.Id == occasionId, cancellationToken)
                    ?? throw new ArgumentException("查無場合資料");

                reservationGroupQuery.StyleId = styleQuery.Id;
                reservationGroupQuery.OccasionId = occasionQuery.Id;
                reservationGroupQuery.ModifiedAt = DateTime.Now;
                reservationGroupQuery.ModifiedBy = _authenticatedUserService.UserId;
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new SubmitReservationGroupResposne();
        }
    }
}
