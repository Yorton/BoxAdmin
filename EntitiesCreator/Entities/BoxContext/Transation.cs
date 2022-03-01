using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Transation
    {
        public Guid Id { get; set; }
        public string TransactionNo { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? InvoiceId { get; set; }
        public int Type { get; set; }
        public decimal DiscountFee { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int State { get; set; }
        public int PayType { get; set; }
        public string CardNumber { get; set; }
        public string RecipientName { get; set; }
        public int RecipientCountry { get; set; }
        public string RecipientZip { get; set; }
        public string RecipientCity { get; set; }
        public string RecipientRegion { get; set; }
        public string RecipientAddress { get; set; }
        public string RecipientMobile { get; set; }
        public int DeliveryMethod { get; set; }
        public string StoreReceiveStoreCode { get; set; }
        public string StoreReceiveStoreName { get; set; }
        public string StoreReceiveShippingRoute { get; set; }
        public string Remark { get; set; }
        public bool Verify { get; set; }
        public string VerifyAuditor { get; set; }
        public string VerifyRemark { get; set; }
        public int PreOrder { get; set; }
        public string Platform { get; set; }
        public string Source { get; set; }
        public string CreatorIp { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedDate { get; set; }
        public TimeSpan CreatedTime { get; set; }
    }
}
