using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class TakeCp
    {
        public Guid MarketingActivitiesId { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string SpecialCode { get; set; }
    }
}
