using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ReservationCustomer
    {
        public Guid ReservationId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Reservation Reservation { get; set; }
    }
}
