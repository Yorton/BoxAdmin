using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class EcpayInvoiceLog
    {
        public Guid Id { get; set; }
        public string Store { get; set; }
        public string OrderNo { get; set; }
        public string Type { get; set; }
        public decimal? Amt { get; set; }
        public bool? IsPrint { get; set; }
        public int? CarrierType { get; set; }
        public bool? IsDonation { get; set; }
        public string LoveCode { get; set; }
        public string CarruerNo { get; set; }
        public string CustId { get; set; }
        public string GuiNo { get; set; }
        public string CustName { get; set; }
        public string CustAddr { get; set; }
        public string CustPhone { get; set; }
        public string CustEmail { get; set; }
        public string Remark { get; set; }
        public string MerchantId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string RandomNumber { get; set; }
        public string Reason { get; set; }
        public string RtnCode { get; set; }
        public string RtnMsg { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Items { get; set; }
    }
}
