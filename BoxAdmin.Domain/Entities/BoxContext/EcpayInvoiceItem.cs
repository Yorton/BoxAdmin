using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class EcpayInvoiceItem
    {
        public string IisNumber { get; set; }
        public int ItemSeq { get; set; }
        public string ItemName { get; set; }
        public decimal ItemCount { get; set; }
        public string ItemWord { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemTaxType { get; set; }
        public decimal ItemAmount { get; set; }
        public string ItemRemark { get; set; }
    }
}
