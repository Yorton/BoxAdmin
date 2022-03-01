using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class EcpayInvoice
    {
        public string IisNumber { get; set; }
        public string IisMerId { get; set; }
        public string IisRelateNumber { get; set; }
        public string IisCustomerId { get; set; }
        public string IisIdentifier { get; set; }
        public string IisCustomerName { get; set; }
        public string IisCustomerAddr { get; set; }
        public string IisCustomerPhone { get; set; }
        public string IisCustomerEmail { get; set; }
        public string IisClearanceMark { get; set; }
        public string IisType { get; set; }
        public string IisCategory { get; set; }
        public string IisTaxType { get; set; }
        public string SpecialTaxType { get; set; }
        public decimal? IisTaxRate { get; set; }
        public decimal? IisTaxAmount { get; set; }
        public decimal? IisSalesAmount { get; set; }
        public string IisCheckNumber { get; set; }
        public string IisCarrierType { get; set; }
        public string IisCarrierNum { get; set; }
        public string IisLoveCode { get; set; }
        public string IisIp { get; set; }
        public DateTime? IisCreateDate { get; set; }
        public string IisIssueStatus { get; set; }
        public string IisInvalidStatus { get; set; }
        public string IisUploadStatus { get; set; }
        public DateTime? IisUploadDate { get; set; }
        public string IisTurnkeyStatus { get; set; }
        public decimal? IisRemainAllowanceAmt { get; set; }
        public string IisPrintFlag { get; set; }
        public string IisAwardFlag { get; set; }
        public string IisAwardType { get; set; }
        public string IisRandomNumber { get; set; }
        public string InvoiceRemark { get; set; }
        public string PosBarCode { get; set; }
        public string QrcodeLeft { get; set; }
        public string QrcodeRight { get; set; }
        public bool IsInvalid { get; set; }
        public string IiInvoiceNo { get; set; }
        public DateTime? IiDate { get; set; }
        public string IiUploadStatus { get; set; }
        public DateTime? IiUploadDate { get; set; }
        public string Reason { get; set; }
        public string IiSellerIdentifier { get; set; }
        public string IiBuyerIdentifier { get; set; }
    }
}
