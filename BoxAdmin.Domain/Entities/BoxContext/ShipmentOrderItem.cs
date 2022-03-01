using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ShipmentOrderItem
    {
        public Guid Id { get; set; }
        public Guid ShipmentId { get; set; }
        public Guid OrderItemId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
