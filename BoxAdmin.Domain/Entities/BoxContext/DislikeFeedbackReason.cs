using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class DislikeFeedbackReason
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
