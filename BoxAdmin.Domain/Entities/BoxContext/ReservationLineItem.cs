using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ReservationLineItem
    {
        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public Guid GroupId { get; set; }
        public string Sku { get; set; }
        public string CustomerSku { get; set; }
        public int Status { get; set; }
        public int Source { get; set; }
        public bool DislikeFeedback { get; set; }
        public string DislikeReason { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public int Position { get; set; }

        public virtual ReservationLineItemGroup Group { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
