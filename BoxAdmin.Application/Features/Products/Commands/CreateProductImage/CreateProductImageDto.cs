using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Products.Commands.CreateProductImage
{
    public class CreateProductImageDto
    {
        public string Color { get; set; }
        public int Type { get; set; }
        public int Sort { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
    }
}
