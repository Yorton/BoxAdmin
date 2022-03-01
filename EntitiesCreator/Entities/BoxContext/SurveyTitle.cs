using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class SurveyTitle
    {
        public int Id { get; set; }
        public Guid SurveyId { get; set; }
        public string SurveyType { get; set; }
        public int No { get; set; }
        public string NoName { get; set; }
        public string SubNo { get; set; }
        public string SubNoName { get; set; }
        public bool IsMapping { get; set; }
    }
}
