using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class CouponRule
    {
        public Guid Id { get; set; }
        public int UseLimitType { get; set; }
        public string CartType { get; set; }
        public int DiscountThresholdType { get; set; }
        public int? DiscountThresholdValue { get; set; }
        public int DiscountTarget { get; set; }
        public int DiscountContentType { get; set; }
        public int DiscountContentValue { get; set; }
        public bool Enable { get; set; }
    }
}
