using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Subscribe
    {
        public Guid Id { get; set; }
        public string SubscribeNo { get; set; }
        public int SubscriptionPlanId { get; set; }
        public Guid CustomerId { get; set; }
        public bool? AutoRenew { get; set; }
        public DateTime DueDate { get; set; }
        public int State { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
