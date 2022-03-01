
using MediatR;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace BoxAdmin.Application.Test.Features
{
    using ReservationsCommands = Application.Features.Reservations.Commands;

    public class ReservationsTest
    {
        private readonly IMediator _mediator;
        public ReservationsTest(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Fact]
        public async Task ReservationsFeature_AddReservationLineItem()
        {
            var js = "{ \"id\": \"8DE8C8F0-F103-4459-A762-255EADE92DB8\", \"groups\": [ { \"id\": \"0CB022DB-3850-492A-B823-2FE874D66187\", \"sortNum\": 1, \"items\": [ { \"position\": 1, \"sku\": \"IR0032-1-M\", \"source\": 2 }, { \"position\": 2, \"sku\": \"IR0017-2-M\", \"source\": 3 } ] }, { \"id\": \"D662F00D-54F3-4995-86E3-1582FAD875EA\", \"sortNum\": 2, \"items\": [ { \"position\": 1, \"sku\": \"IR0017-2-M\", \"source\": 2 }, { \"position\": 2, \"sku\": \"IR0017-2-M\", \"source\": 3 } ] }, { \"id\": \"00000000-0000-0000-0000-000000000000\", \"sortNum\": 3, \"items\": [ { \"position\": 1, \"sku\": \"IR0032-1-M\", \"source\": 2 }, { \"position\": 2, \"sku\": \"IR0032-1-M\", \"source\": 3 } ] } ] }";
            var request = JsonConvert.DeserializeObject<ReservationsCommands.AddReservationLineItem.AddReservationLineItemCommand>(js);
            var response = await _mediator.Send(request);
            Assert.NotNull(response);
        }
    }
}
