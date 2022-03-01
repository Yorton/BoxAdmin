using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class PageFrameContent
    {
        public Guid Id { get; set; }
        public Guid PageFrameId { get; set; }
        public string RelatedId { get; set; }
        public int Sort { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
    }
}
