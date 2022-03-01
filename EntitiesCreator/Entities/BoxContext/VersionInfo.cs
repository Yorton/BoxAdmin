using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class VersionInfo
    {
        public string Android { get; set; }
        public DateTime AndroidTimeStamp { get; set; }
        public string IOs { get; set; }
        public DateTime IOstimeStamp { get; set; }
    }
}
