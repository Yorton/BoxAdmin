using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class Qa
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public int Catelog { get; set; }
        public string Subject { get; set; }
        public string Question { get; set; }
        public DateTime QuestionDate { get; set; }
        public string Answerer { get; set; }
        public string Answer { get; set; }
        public DateTime? AnswerDate { get; set; }
    }
}
