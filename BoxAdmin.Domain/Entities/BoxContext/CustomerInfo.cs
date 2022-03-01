using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class CustomerInfo
    {
        public CustomerInfo()
        {
            Accounts = new HashSet<Account>();
        }

        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public bool? Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public int? Country { get; set; }
        public string CompanyNo { get; set; }
        public string CompanyTitle { get; set; }
        public string PhoneCountryCode { get; set; }

        public virtual CustomerDatum CustomerDatum { get; set; }
        public virtual DeviceInfo DeviceInfo { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
