using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Invoice
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool? Donate { get; set; }
        public string DonateCode { get; set; }
        public int? DeviceType { get; set; }
        public string DeviceCode { get; set; }
        public string Receiver { get; set; }
        public string ReceiverTel { get; set; }
        public string ReceiverAddress { get; set; }
        public string CompanyNumber { get; set; }
    }
}
