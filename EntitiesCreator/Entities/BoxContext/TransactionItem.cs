using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class TransactionItem
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public string Sku { get; set; }
        public string SkuName { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Discount { get; set; }
        public int Quentity { get; set; }
        public decimal TotalPrice { get; set; }
        public int Currency { get; set; }
        public int State { get; set; }
        public bool Verifity { get; set; }
        public int OrderType { get; set; }
        public string Store { get; set; }
        public int PromoId { get; set; }
        public int TrackingId { get; set; }
        public string ReturnNo { get; set; }
        public int? ReturnOrderState { get; set; }
        public int? ReturnReasonType { get; set; }
        public DateTime? ReturnTime { get; set; }
        public decimal ProductCost { get; set; }
        public int ProductCostCurrency { get; set; }
        public int? EventId { get; set; }
        public int? CouponAmt { get; set; }
        public double? RealCouponAmt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
