using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ProductTryReport
    {
        public Guid Id { get; set; }
        public string Series { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ModelHipWidth { get; set; }
        public string ModelWaistWidth { get; set; }
        public string ModelBustWidth { get; set; }
        public string ModelWeight { get; set; }
        public string ModelHeight { get; set; }
        public string TryReport { get; set; }
        public string SizeMetrology { get; set; }
        public string UpperBodySize { get; set; }
        public string LowerBodySize { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
