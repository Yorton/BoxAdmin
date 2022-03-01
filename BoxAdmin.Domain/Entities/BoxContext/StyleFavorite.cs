using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class StyleFavorite
    {
        public Guid CustomerId { get; set; }
        public Guid StyleBookId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
