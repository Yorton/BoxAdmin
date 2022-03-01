using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AutoMapper;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace BoxAdmin.Application.Features.Reservations.Commands.SubmitReservationCard
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using BoxAdmin.Application.DTOs.Settings;
    using BoxAdmin.Application.DTOs.Images;

    public class SubmitReservationCardCommand : IRequest<SubmitReservationCardResponse>
    {
        [SwaggerSchema("卡片製作ID")] public Guid Id { get; set; }
        [SwaggerSchema("版型類別")] public int Template { get; set; }
        [SwaggerSchema("問候語")] public string Intro { get; set; }
        [SwaggerSchema("簽名檔")] public string SignatureUrl { get; set; }
        [SwaggerSchema("商品組合搭配文案")] public List<SubmitReservationCardCommand_ReservationLineItemGroup> Groups { get; set; }
        public class SubmitReservationCardCommand_ReservationLineItemGroup
        {
            [SwaggerSchema("GroupId")] public Guid Id { get; set; }
            [SwaggerSchema("搭配文案")] public string Message { get; set; }
        }
    }

    public class StyleBookImageSubmitHandler : IRequestHandler<SubmitReservationCardCommand, SubmitReservationCardResponse>
    {
        private readonly CommonSettings _commonSettings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public StyleBookImageSubmitHandler(
            IOptions<CommonSettings> commonSettings,
            IMapper mapper,
            IBoxDbContext context,
            IAuthenticatedUserService authenticatedUserService)
        {
            _commonSettings = commonSettings.Value;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<SubmitReservationCardResponse> Handle(SubmitReservationCardCommand command, CancellationToken cancellationToken)
        {
            var cardQuery = await _context.ReservationCards
                .Include(x => x.Reservation)
                .SingleOrDefaultAsync(x => x.Id == command.Id, cancellationToken)
                ?? throw new ArgumentException("查無資料", nameof(command.Id));

            cardQuery.Intro = command.Intro;
            cardQuery.SignatureUrl = command.SignatureUrl.Replace(_commonSettings.BoxImageUrl, "");

            var groupsQuery = await _context.ReservationLineItemGroups.Where(x => x.ReservationId == cardQuery.Reservation.Id).ToListAsync(cancellationToken);
            foreach(var item in command.Groups)
            {
                var groupItemQuery = groupsQuery.SingleOrDefault(x => x.Id == item.Id);

                groupItemQuery.MatchingMessage = item.Message;
                groupItemQuery.ModifiedAt = DateTime.Now;
                groupItemQuery.ModifiedBy = _authenticatedUserService.UserId;
            }

            cardQuery.ModifiedAt = DateTime.Now;
            cardQuery.ModifiedBy = _authenticatedUserService.UserId;

            await _context.SaveChangesAsync(cancellationToken);

            return new SubmitReservationCardResponse();
        }
    }
}
