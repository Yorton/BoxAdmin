using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BoxAdmin.Application.DTOs.Images
{
    public class UploadImageCommand
    {
        public Stream ImputStream { get; set; }
        /// <summary>
        /// 檔名(含附檔名)
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 目錄路徑(ex Folder/SubFolder/)
        /// </summary>
        public string DirecotryUploadPath { get; set; }
        public string DirecotryPath { get; set; }
        public string ToFullPath() => this.DirecotryPath + this.FileName;
    }
}
