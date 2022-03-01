using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ProductImage
    {
        public string Series { get; set; }
        public string Color { get; set; }
        public int Type { get; set; }
        public int Sort { get; set; }
        public string ImagePath { get; set; }
        public string Filename { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string Modifier { get; set; }
    }
}
