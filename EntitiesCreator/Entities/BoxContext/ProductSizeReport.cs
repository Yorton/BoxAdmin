using System;
using System.Collections.Generic;

#nullable disable

namespace BoxAdmin.Domain.Entities.BoxContext
{
    public partial class ProductSizeReport
    {
        public string Series { get; set; }
        public string Size { get; set; }
        public string UpperBust { get; set; }
        public string Bust { get; set; }
        public string UnderBust { get; set; }
        public string WaistCircumference { get; set; }
        public string AbdominalCircumference { get; set; }
        public string HipCircumference { get; set; }
        public string ThighCircumference { get; set; }
        public string Crotch { get; set; }
        public string TrouserWidth { get; set; }
        public string Hem { get; set; }
        public string SleeveLength { get; set; }
        public string ArmpitCircumference { get; set; }
        public string ArmCircumference { get; set; }
        public string ArmholeCircumference { get; set; }
        public string ShoulderWidth { get; set; }
        public string Sleeve { get; set; }
        public string FullLength { get; set; }
        public string TubeLength { get; set; }
        public string TubeCircumference { get; set; }
        public string HeelHigh { get; set; }
        public string TryDescription { get; set; }
        public string FitSizeMin { get; set; }
        public string FitSizeMax { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
