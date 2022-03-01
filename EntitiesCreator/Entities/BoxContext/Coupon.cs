using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Coupon
    {
        public string Id { get; set; }
        public Guid? MarketingActivitiesId { get; set; }
        public Guid CouponRuleId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? CustomerId { get; set; }
        public string SpecialCode { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? UsedDate { get; set; }
        public Guid? TransactionId { get; set; }
    }
}
