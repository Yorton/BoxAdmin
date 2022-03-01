using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class BoxDataSync
    {
        public long Id { get; set; }
        public string Method { get; set; }
        public string SyncValue { get; set; }
        public string SyncAction { get; set; }
        public bool Sync { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
