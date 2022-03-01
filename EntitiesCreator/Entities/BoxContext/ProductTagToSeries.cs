using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ProductTagToSeries
    {
        public string SeriesNo { get; set; }
        public string Type { get; set; }
        public string GroupKey { get; set; }
        public string TagCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
