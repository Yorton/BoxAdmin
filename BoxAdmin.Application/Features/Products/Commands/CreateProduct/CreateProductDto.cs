using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductSeriesDto
    {
        /// <summary>
        /// 主系列編號
        /// </summary>
        public string SeriesNo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool OverseasDelivery { get; set; }
        public string Brand { get; set; }
        public string Material { get; set; }
        public string Origin { get; set; }
        public string Color { get; set; }
        public string Accessories { get; set; }
        public string Attention { get; set; }
        public List<CreateProductItemDto> Items { get; set; }
    }

    public class CreateProductItemDto
    {
        public string Series { get; set; }
        public string SubSeries { get; set; }
        public string Sku { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int SellingPrice { get; set; }
        public int Stock { get; set; }
        public decimal Weight { get; set; }
    }
}
