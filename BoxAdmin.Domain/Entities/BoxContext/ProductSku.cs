using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ProductSku
    {
        public string Series { get; set; }
        public string SubSeries { get; set; }
        public string Sku { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int SellingPrice { get; set; }
        public int Stock { get; set; }
        public int PreStock { get; set; }
        public decimal Weight { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Enable { get; set; }
    }
}
