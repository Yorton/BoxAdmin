using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class EcpayAllowanceLog
    {
        public Guid Id { get; set; }
        public string StoreId { get; set; }
        public string StoreName { get; set; }
        public int AreaId { get; set; }
        public string VatNumber { get; set; }
        public string InvoiceNo { get; set; }
        public string Type { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public string MerchantId { get; set; }
        public string AllowanceNotify { get; set; }
        public string CustomerName { get; set; }
        public string NotifyMail { get; set; }
        public string NotifyPhone { get; set; }
        public decimal? AllowanceAmount { get; set; }
        public string ReturnUrl { get; set; }
        public string AllowanceNo { get; set; }
        public string Reason { get; set; }
        public string RtnCode { get; set; }
        public string RtnMsg { get; set; }
        public string IaAllowNo { get; set; }
        public string IaInvoiceNo { get; set; }
        public string IaDate { get; set; }
        public decimal? IaRemainAllowanceAmt { get; set; }
        public string IaTempDate { get; set; }
        public string IaTempExpireDate { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Items { get; set; }
    }
}
