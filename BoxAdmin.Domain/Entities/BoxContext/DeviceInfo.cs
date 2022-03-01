using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class DeviceInfo
    {
        public Guid CustomerId { get; set; }
        public string DeviceId { get; set; }
        public byte Platform { get; set; }
        public string Osversion { get; set; }
        public string Version { get; set; }

        public virtual CustomerInfo Customer { get; set; }
    }
}
