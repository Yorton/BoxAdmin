using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class EcpayAllowance
    {
        public string InvoiceNo { get; set; }
        public string IaAllowNo { get; set; }
        public string IaCheckSendMail { get; set; }
        public DateTime? IaDate { get; set; }
        public string IaIp { get; set; }
        public string IaIdentifier { get; set; }
        public string IaInvalidStatus { get; set; }
        public DateTime? IaInvoiceIssueDate { get; set; }
        public string IaInvoiceNo { get; set; }
        public string IaMerId { get; set; }
        public string IaSendMail { get; set; }
        public string IaSendPhone { get; set; }
        public decimal? IaTaxAmount { get; set; }
        public string IaTaxType { get; set; }
        public decimal? IaTotalAmount { get; set; }
        public decimal? IaTotalTaxAmount { get; set; }
        public DateTime? IaUploadDate { get; set; }
        public string IaUploadStatus { get; set; }
        public string IisCustomerName { get; set; }
        public bool IsInvalid { get; set; }
        public DateTime? AiAllowDate { get; set; }
        public string AiAllowNo { get; set; }
        public string AiBuyerIdentifier { get; set; }
        public DateTime? AiDate { get; set; }
        public string AiInvoiceNo { get; set; }
        public string AiMerId { get; set; }
        public string Reason { get; set; }
        public string AiSellerIdentifier { get; set; }
        public DateTime? AiUploadDate { get; set; }
        public string AiUploadStatus { get; set; }
    }
}
