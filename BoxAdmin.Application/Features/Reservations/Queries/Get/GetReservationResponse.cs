using System.Collections.Generic;

namespace BoxAdmin.Application.Features.Reservations.Queries.Get
{
    public class GetReservationResponse
    {
        public List<ReservationItem> Items { get; set; }

        public GetReservationResponse() : this(new List<ReservationItem>()) { }
        public GetReservationResponse(List<ReservationItem> items)
        {
            Items = items;
        }
    }
}
