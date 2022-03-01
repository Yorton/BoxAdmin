using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class CustomerDatum
    {
        public bool? InvoiceBind { get; set; }
        public DateTime? InvoiceBindDate { get; set; }
        public Guid CustomerId { get; set; }
        public bool? ArrivalNotice { get; set; }
        public DateTime? ArrivalNoticeDate { get; set; }
        public string Currency { get; set; }
        public Guid? Obuid { get; set; }
        public DateTime? FirstPurchaseDate { get; set; }
        public DateTime? ChangePasswordDate { get; set; }
        public int LoginFailCount { get; set; }
        public int ValidateCount { get; set; }
        public int ValidateFailCount { get; set; }
        public string ValidateCode { get; set; }
        public string ValidateMappingCode { get; set; }
        public DateTime? ValidateDate { get; set; }
        public string LineDisplayName { get; set; }
        public bool? LineBind { get; set; }
        public bool? Obfriend { get; set; }
        public bool? ValidMobile { get; set; }
        public bool? ValidEmail { get; set; }
        public int? VipLevel { get; set; }
        public DateTime? VipStartDate { get; set; }
        public DateTime? VipEndDate { get; set; }
        public string DeviceId { get; set; }
        public int GroupType { get; set; }
        public bool? Edm { get; set; }
        public string 修改郵件帳號紀錄 { get; set; }
        public int? Store { get; set; }
        public bool BindOpenpoint { get; set; }
        public bool Auth3Dok { get; set; }
        public int? CheckData { get; set; }

        public virtual CustomerInfo Customer { get; set; }
    }
}
