using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ProductFavorite
    {
        public Guid CustomerId { get; set; }
        public string Series { get; set; }
        public string Color { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
