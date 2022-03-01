using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

using BoxAdmin.Application.DTOs.Images;
using BoxAdmin.Infrastructure.Shared;

namespace BoxAdmin.Infrastructure.Test
{
    public class AwsWrapperServiceTests
    {
        [Fact]
        public async Task UploadImageTest()
        {
            var service = new AwsWrapperService();
            using var fs = new FileStream("177.jpg", FileMode.Open, FileAccess.Read);
            await service.UploadImageAsync("AKIAXVRZ2H4CP2BN55OV", "CH3D/HFzbgT+edkDrdcov6+CItdSARSngWOw+yUs", fs);
        }

        [Fact]
        public async Task UploadImage_Using_CommandObject_Test()
        {
            var service = new AwsWrapperService();
            using var fs = new FileStream("177.jpg", FileMode.Open, FileAccess.Read);
            await service.UploadImageAsync("AKIAXVRZ2H4CP2BN55OV", "CH3D/HFzbgT+edkDrdcov6+CItdSARSngWOw+yUs", new UploadImageCommand()
            {
                ImputStream = fs,
                FileName = $"{Guid.NewGuid()}.jpg",
                DirecotryPath = "test/test2/"
            });
        }
    }
}
