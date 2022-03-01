using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class SurveyAnswer
    {
        public Guid SurveyId { get; set; }
        public Guid CustomerId { get; set; }
        public string TopicNo1 { get; set; }
        public string TopicNo2 { get; set; }
        public string TopicNo3 { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
        public Guid? SurveyReplyId { get; set; }
    }
}
