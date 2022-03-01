using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class AbandonedCart
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public DateTime ModifityDate { get; set; }
        public TimeSpan ModifityTime { get; set; }
        public string Source { get; set; }
    }
}
