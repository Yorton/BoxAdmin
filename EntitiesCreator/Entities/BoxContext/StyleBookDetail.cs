using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class StyleBookDetail
    {
        public Guid Id { get; set; }
        public Guid StyleBookId { get; set; }
        public string Series { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        public string CatelogName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }

        public virtual StyleBook StyleBook { get; set; }
    }
}
