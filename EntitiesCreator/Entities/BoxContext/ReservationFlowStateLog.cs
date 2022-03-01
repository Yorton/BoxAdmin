using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ReservationFlowStateLog
    {
        public int Id { get; set; }
        public Guid ReservationId { get; set; }
        public int FlowState { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
