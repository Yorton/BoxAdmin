using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ReservationRecipient
    {
        public Guid ReservationId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string Mobile { get; set; }
        public int Country { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
