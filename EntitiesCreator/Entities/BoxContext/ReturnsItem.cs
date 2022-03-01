using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ReturnsItem
    {
        public long IdReturnsItem { get; set; }
        public Guid Id { get; set; }
        public Guid ReturnsId { get; set; }
        public Guid OrderItemId { get; set; }
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
