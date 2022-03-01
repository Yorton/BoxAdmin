using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Account
    {
        public Guid CustomerId { get; set; }
        public int Type { get; set; }
        public string Account1 { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Enable { get; set; }
        public Guid SyncGuid { get; set; }

        public virtual CustomerInfo Customer { get; set; }
    }
}
