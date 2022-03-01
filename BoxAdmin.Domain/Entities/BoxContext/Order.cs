using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Order
    {
        public long IdOrder { get; set; }
        public Guid TransactionId { get; set; }
        public Guid SourceTransactionNo { get; set; }
        public string TransactionNo { get; set; }
        public Guid CustomerId { get; set; }
        public int OrderType { get; set; }
        public string Currency { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PaymentAmt { get; set; }
        public DateTime OrderTime { get; set; }
        public int OrderState { get; set; }
        public int PayType { get; set; }
        public string CardNumber { get; set; }
        public string TaxIdNumber { get; set; }
        public string OrdererName { get; set; }
        public string RecipientName { get; set; }
        public int Country { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public int MobileEncrypt { get; set; }
        public int DeliveryMethod { get; set; }
        public string StorePickupCode { get; set; }
        public string StorePickupName { get; set; }
        public string ShippingRoute { get; set; }
        public string Remark { get; set; }
        public bool Verify { get; set; }
        public string VerifyAuditor { get; set; }
        public string VerifyRemark { get; set; }
        public int PreOrder { get; set; }
        public string Ip { get; set; }
        public string Platform { get; set; }
        public string Source { get; set; }
        public string InvTitle { get; set; }
        public bool? InvDonateYn { get; set; }
        public string InvDonateCode { get; set; }
        public string InvDevice { get; set; }
        public string InvDeviceCode { get; set; }
        public string InvReceiver { get; set; }
        public string InvReceiverTel { get; set; }
        public string InvReceiverAddr { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
