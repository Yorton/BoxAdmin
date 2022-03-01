using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class SmsMessageDatum
    {
        public SmsMessageDatum()
        {
            SmsMessageResults = new HashSet<SmsMessageResult>();
        }

        public Guid Id { get; set; }
        public string Sender { get; set; }
        public string MobileNumber { get; set; }
        public bool? Encrypted { get; set; }
        public DateTime? SendTime { get; set; }
        public string Content { get; set; }
        public bool Send { get; set; }
        public int Status { get; set; }
        public int? Priority { get; set; }
        public string Manufacture { get; set; }
        public string MessageTokenId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<SmsMessageResult> SmsMessageResults { get; set; }
    }
}
