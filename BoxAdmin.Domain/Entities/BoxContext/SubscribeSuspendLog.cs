using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class SubscribeSuspendLog
    {
        public int Id { get; set; }
        public Guid SubscribeId { get; set; }
        public Guid CustomerId { get; set; }
        public int SuspendState { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
