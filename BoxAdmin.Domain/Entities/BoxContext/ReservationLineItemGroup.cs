using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ReservationLineItemGroup
    {
        public ReservationLineItemGroup()
        {
            ReservationLineItems = new HashSet<ReservationLineItem>();
        }

        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public string MatchingMessage { get; set; }
        public Guid? StyleId { get; set; }
        public Guid? OccasionId { get; set; }
        public int SortNum { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual ICollection<ReservationLineItem> ReservationLineItems { get; set; }
    }
}
