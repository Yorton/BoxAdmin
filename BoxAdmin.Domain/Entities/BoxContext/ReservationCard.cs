using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ReservationCard
    {
        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public int Template { get; set; }
        public string Intro { get; set; }
        public string SignatureUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
