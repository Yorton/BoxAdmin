using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class StyleBookCondition
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int Sort { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
