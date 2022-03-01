using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class SurveyTitleMapping
    {
        public int Id { get; set; }
        public Guid SurveyId { get; set; }
        public string SurveyType { get; set; }
        public int No { get; set; }
        public string SubNo { get; set; }
        public string Answer { get; set; }
        public string AnswerName { get; set; }
    }
}
