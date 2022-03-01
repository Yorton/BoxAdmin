using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookExport
{
    public class StyleBookExportResponse
    {
        public string DownloadPath { get; set; }
    }
}
