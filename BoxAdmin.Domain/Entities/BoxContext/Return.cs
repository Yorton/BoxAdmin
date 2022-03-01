using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Return
    {
        public long IdReturns { get; set; }
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; }
        public string RtnNo { get; set; }
        public DateTime? RtnDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
