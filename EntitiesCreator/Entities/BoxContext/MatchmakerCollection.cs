using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class MatchmakerCollection
    {
        public int Id { get; set; }
        public Guid MatchmakerId { get; set; }
        public string Sku { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual MatchmakerInfo Matchmaker { get; set; }
    }
}
