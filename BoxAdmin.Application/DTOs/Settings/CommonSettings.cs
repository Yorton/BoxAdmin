using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.DTOs.Settings
{
    public class CommonSettings
    {
        public string BoxImageUrl { get; set; }
        public BoxImageDirectory BoxImageDirectory { get; set; }
    }

    public class BoxImageDirectory
    {
        public string StyleBook { get; set; }
        public string MatchingMakerInfo { get; set; }
        public string StyleBookUploadPath { get; set; }
        public string MatchingMakerInfoUploadPath { get; set; }
    }
}
