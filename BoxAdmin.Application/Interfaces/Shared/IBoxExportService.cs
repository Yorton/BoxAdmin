using BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Application.Interfaces.Shared
{
    public interface IBoxExportService
    {
        string ExportStyleBookList(List<ExportItem> dataList);
    }
}
