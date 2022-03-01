using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class PageFrame
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int FrameType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
        public int Sort { get; set; }
    }
}
