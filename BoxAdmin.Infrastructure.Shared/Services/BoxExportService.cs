using Aspose.Cells;
using Aspose.Cells.Drawing;
using BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookExport;
using BoxAdmin.Application.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace BoxAdmin.Infrastructure.Shared.Services
{
    public class BoxExportService : IBoxExportService
    {
        public string ExportStyleBookList(List<ExportItem> dataList)
        {
            Workbook wb = new Workbook();
            Worksheet ws = wb.Worksheets[0];
            var fileName = string.Format("搭配師後台stylebook匯出_{0}.xlsx", DateTime.Now.ToString("yyyyMMdd"));
            ws.Name = "StyleBook";

            ImportTableOptions tableOptions = new ImportTableOptions();
            tableOptions.IsFieldNameShown = true;

            ws.Cells.ImportCustomObjects(dataList, 0, 0, tableOptions);
            ws.Cells.SetColumnWidthPixel(3, 130);
            ws.Cells.SetColumnWidthPixel(5, 130);

            for (int i = 1; i <= dataList.Count; i++)
            {
                ws.Cells.SetRowHeightPixel(i, 170);
                ws.Cells.Rows[i][3].Value = string.Empty;
                ws.Cells.Rows[i][5].Value = string.Empty;
                using (var webClient = new WebClient())
                {
                    byte[] imageBytes1 = webClient.DownloadData(dataList[i - 1].商品色塊主圖1照片);
                    byte[] imageBytes2 = webClient.DownloadData(dataList[i - 1].商品色塊主圖2照片);

                    MemoryStream ms1 = new MemoryStream();
                    ms1.Write(imageBytes1, 0, imageBytes1.Length);
                    int index1 = ws.Pictures.Add(i, 3, ms1);
                    Picture pic1 = ws.Pictures[index1];
                    double ratio1 = 1;
                    double heightRatio1 = pic1.Height / 160.00;
                    double widthRatio1 = pic1.Width / 120.00;
                    if (pic1.Height / widthRatio1 <= 160)
                    {
                        ratio1 = widthRatio1;
                    }
                    else 
                    {
                        ratio1 = heightRatio1;
                    }
                    pic1.Height = Convert.ToInt32(Math.Round(pic1.Height / ratio1));
                    pic1.Width = Convert.ToInt32(Math.Round(pic1.Width / ratio1));
                    pic1.IsLockAspectRatio = true;

                    MemoryStream ms2 = new MemoryStream();
                    ms2.Write(imageBytes2, 0, imageBytes2.Length);
                    int index2 = ws.Pictures.Add(i, 5, ms2);
                    Picture pic2 = ws.Pictures[index2];
                    double ratio2 = 1;
                    double heightRatio2 = pic2.Height / 160.00;
                    double widthRatio2 = pic2.Width / 120.00;
                    if (pic2.Height / widthRatio2 <= 160)
                    {
                        ratio2 = widthRatio2;
                    }
                    else
                    {
                        ratio2 = heightRatio2;
                    }
                    pic2.Height = Convert.ToInt32(Math.Round(pic2.Height / ratio2));
                    pic2.Width = Convert.ToInt32(Math.Round(pic2.Width / ratio2));
                    pic2.IsLockAspectRatio = true;
                }
            }

            var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", "Export", "StyleBook");
            var exists = Directory.Exists(root);
            if (!exists)
            {
                Directory.CreateDirectory(root);
            }
            var path = Path.Combine(root, fileName);
            wb.Save(path, SaveFormat.Xlsx);

            var downloadPath = Path.Combine("..", "Temp", "Export", "StyleBook", fileName);

            return downloadPath;
        }
    }
}
