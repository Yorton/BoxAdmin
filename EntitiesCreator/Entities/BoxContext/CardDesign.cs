using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class CardDesign
    {
        public Guid Id { get; set; }
        public Guid ReservationId { get; set; }
        public int Template { get; set; }
        public string Intro { get; set; }
        public int? SignatureId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
