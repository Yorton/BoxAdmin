using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace BoxAdmin.Application.Interfaces.Shared
{
    using BoxAdmin.Application.DTOs.Images;

    public interface IAwsWrapperService
    {
        Task<string> UploadImageAsync(string accessKeyId, string secretAccessKey, Stream stream);
        Task<string> UploadImageAsync(string accessKeyId, string secretAccessKey, UploadImageCommand command, CancellationToken cancellationToken = default);
    }
}
