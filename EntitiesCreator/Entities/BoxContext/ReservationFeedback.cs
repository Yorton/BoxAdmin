using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ReservationFeedback
    {
        public int Id { get; set; }
        public Guid ReservationId { get; set; }
        public Guid ReservationLineItemId { get; set; }
        public int Reason { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual ReservationLineItem ReservationLineItem { get; set; }
    }
}
