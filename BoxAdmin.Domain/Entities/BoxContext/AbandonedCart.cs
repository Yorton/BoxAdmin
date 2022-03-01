using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class AbandonedCart
    {
        public string Account { get; set; }
        public DateTime ModifityDateTime { get; set; }
        public string Store { get; set; }
    }
}
