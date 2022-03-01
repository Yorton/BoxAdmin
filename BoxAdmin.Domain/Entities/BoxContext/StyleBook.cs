using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class StyleBook
    {
        public StyleBook()
        {
            StyleBookDetails = new HashSet<StyleBookDetail>();
        }

        public Guid Id { get; set; }
        public Guid MatchmakerInfoId { get; set; }
        public Guid StyleId { get; set; }
        public Guid OccasionId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int? Sort { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
        public int State { get; set; }

        public virtual ICollection<StyleBookDetail> StyleBookDetails { get; set; }
    }
}
