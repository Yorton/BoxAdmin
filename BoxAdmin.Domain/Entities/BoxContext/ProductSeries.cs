using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ProductSeries
    {
        public string Series { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriceMin { get; set; }
        public int PriceMax { get; set; }
        public bool OverseasDeliverya { get; set; }
        public string Brand { get; set; }
        public int VendorType { get; set; }
        public DateTime FirstSellDate { get; set; }
        public string Material { get; set; }
        public string Origin { get; set; }
        public string Color { get; set; }
        public string Accessories { get; set; }
        public string Attention { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Enable { get; set; }
    }
}
