using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class OrderRefund
    {
        public long IdOrderRefund { get; set; }
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
        public int Type { get; set; }
        public int OrderPaymentType { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime? RefundDate { get; set; }
        public decimal Amount { get; set; }
        public decimal RealAmount { get; set; }
        public bool CreditBack { get; set; }
        public int UserApply { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public string TransId { get; set; }
    }
}
