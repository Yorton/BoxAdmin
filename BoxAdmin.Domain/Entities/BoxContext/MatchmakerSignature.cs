using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class MatchmakerSignature
    {
        public int Id { get; set; }
        public Guid MatchmakerId { get; set; }
        public string SignImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public virtual MatchmakerInfo Matchmaker { get; set; }
    }
}
