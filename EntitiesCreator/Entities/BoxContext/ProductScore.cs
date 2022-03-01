using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ProductScore
    {
        public Guid CustomerId { get; set; }
        public string Sku { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
