using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class MarketingActivities
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int ReceiveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CanUseType { get; set; }
        public DateTime? CanUseStartDate { get; set; }
        public DateTime? CanUseEndDate { get; set; }
        public int? CanUseByReceiveDay { get; set; }
        public int SendCondition { get; set; }
        public int SendLimitType { get; set; }
        public int LimitQuantity { get; set; }
        public int SendTarget { get; set; }
        public int OutputType { get; set; }
        public int UseLimitType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
    }
}
