using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class MatchmakerInfo
    {
        public MatchmakerInfo()
        {
            MatchmakerCollections = new HashSet<MatchmakerCollection>();
            MatchmakerSignatures = new HashSet<MatchmakerSignature>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string SignatureUrl { get; set; }
        public string SelfIntroduction { get; set; }
        public string Slogan { get; set; }
        public string LikeStyle { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }

        public virtual ICollection<MatchmakerCollection> MatchmakerCollections { get; set; }
        public virtual ICollection<MatchmakerSignature> MatchmakerSignatures { get; set; }
    }
}
