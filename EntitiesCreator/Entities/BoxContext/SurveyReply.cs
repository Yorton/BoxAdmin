using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class SurveyReply
    {
        public int Id { get; set; }
        public int SourceType { get; set; }
        public Guid SourceId { get; set; }
        public Guid SurveyReplyId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
