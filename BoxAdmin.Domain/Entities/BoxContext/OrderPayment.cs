using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class OrderPayment
    {
        public long IdOrderPayment { get; set; }
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
        public int Currency { get; set; }
        public decimal PaymentAmt { get; set; }
        public decimal RealPayment { get; set; }
        public string BankReturnCode { get; set; }
        public string AuthorizationCode { get; set; }
        public string MerchantNumber { get; set; }
        public int PaymentType { get; set; }
        public int State { get; set; }
        public bool Verify { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
