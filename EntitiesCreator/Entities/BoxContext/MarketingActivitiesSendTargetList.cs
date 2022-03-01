using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class MarketingActivitiesSendTargetList
    {
        public Guid Id { get; set; }
        public Guid MarketingActivitiesId { get; set; }
        public string Account { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
