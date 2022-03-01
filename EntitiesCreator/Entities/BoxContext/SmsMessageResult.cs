using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class SmsMessageResult
    {
        public long Id { get; set; }
        public Guid SmsMessageDataId { get; set; }
        public int Status { get; set; }
        public string Result { get; set; }
        public string MsgStatusCode { get; set; }
        public DateTime? CompleteDate { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual SmsMessageDatum SmsMessageData { get; set; }
    }
}
