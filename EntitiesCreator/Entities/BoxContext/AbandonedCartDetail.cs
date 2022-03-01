using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class AbandonedCartDetail
    {
        public Guid Id { get; set; }
        public int AbandonedCartId { get; set; }
        public string MainSeries { get; set; }
        public string Sku { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Volume { get; set; }
        public decimal Weight { get; set; }
        public string PlatForm { get; set; }
        public string Utm { get; set; }
        public int Type { get; set; }
        public int? EventPromoId { get; set; }
        public DateTime AddTime { get; set; }
    }
}
