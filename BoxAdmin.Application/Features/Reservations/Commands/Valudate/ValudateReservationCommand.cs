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

namespace BoxAdmin.Application.Features.Reservations.Commands.Valudate
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using BoxAdmin.Application.DTOs.Settings;
    using BoxAdmin.Application.DTOs.Images;

    public class ValudateReservationCommand : IRequest<ValudateReservationResponse>
    {
        [SwaggerSchema("預約單ID")] public Guid Id { get; set; }
        public ValudateReservationCommand() { }
        public ValudateReservationCommand(Guid id)
        {
            Id = id;
        }
    }

    public class StyleBookImageSubmitHandler : IRequestHandler<ValudateReservationCommand, ValudateReservationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public StyleBookImageSubmitHandler(IMapper mapper, IBoxDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ValudateReservationResponse> Handle(ValudateReservationCommand command, CancellationToken cancellationToken)
        {
            var result = new ValudateReservationResponse();

            var reservationQuery = await _context.Reservations
                .Include(x => x.ReservationLineItems)
                .SingleOrDefaultAsync(x => x.Id == command.Id, cancellationToken)
                ?? throw new ArgumentException("查無資料", $"{nameof(command.Id)} {command.Id}");

            foreach (var lineitem in reservationQuery.ReservationLineItems)
            {
                var productSkuQuery = await _context.ProductSkus.SingleOrDefaultAsync(x => x.Sku == lineitem.Sku, cancellationToken);

                // SKU資料
                if (productSkuQuery == null)
                {
                    result.ValidateResults.Add(new ValudateReservationResponse_ValidateResult(lineitem.Sku, string.Empty, "查無此商品"));
                    continue;
                }

                var productSeriesQuery = await _context.ProductSeries.SingleOrDefaultAsync(x => x.Series == productSkuQuery.Series, cancellationToken);

                // 庫存
                if (productSkuQuery.Stock <= 0)
                {
                    result.ValidateResults.Add(new ValudateReservationResponse_ValidateResult(lineitem.Sku, productSeriesQuery.Name, "無庫存"));
                    continue;
                }
            }

            return result;
        }
    }
}
