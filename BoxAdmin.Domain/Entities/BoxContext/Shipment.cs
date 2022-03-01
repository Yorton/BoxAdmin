using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Shipment
    {
        public long IdShipment { get; set; }
        public Guid ShipmentId { get; set; }
        public Guid TransactionId { get; set; }
        public Guid CustomerId { get; set; }
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
        public DateTime VerifyDate { get; set; }
        public string VerifyAuditor { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime RealShipDate { get; set; }
        public string ShippingNo { get; set; }
        public DateTime InvDate { get; set; }
        public decimal InvAmt { get; set; }
        public bool Invoice { get; set; }
        public bool Payment { get; set; }
        public int State { get; set; }
        public double Weight { get; set; }
    }
}
