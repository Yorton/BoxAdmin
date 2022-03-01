using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BoxAdmin.Application.Interfaces.Shared;
using BoxAdmin.Application.DTOs.Images;

using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;

namespace BoxAdmin.Infrastructure.Shared
{
    public class AwsWrapperService : IAwsWrapperService
    {
        private readonly string _s3Url = "https://ob-image.s3-ap-northeast-1.amazonaws.com/Box_Images/";

        public async Task<string> UploadImageAsync(string accessKeyId, string secretAccessKey, Stream stream)
        {
            var s3Client = new AmazonS3Client(accessKeyId, secretAccessKey, RegionEndpoint.APNortheast1);
            var path = $"{Guid.NewGuid()}.jpg";

            var request = new TransferUtilityUploadRequest()
            {
                InputStream = stream,
                Key = path,
                BucketName = "ob-image/Box_Images",
                CannedACL = S3CannedACL.PublicRead
            };

            var utility = new TransferUtility(s3Client);

            await utility.UploadAsync(request);

            return _s3Url + path;
        }

        public async Task<string> UploadImageAsync(string accessKeyId, string secretAccessKey, UploadImageCommand command, CancellationToken cancellationToken = default)
        {
            var s3Client = new AmazonS3Client(accessKeyId, secretAccessKey, RegionEndpoint.APNortheast1);

            var request = new TransferUtilityUploadRequest()
            {
                InputStream = command.ImputStream,
                Key = $"{command.DirecotryUploadPath}{command.FileName}",
                BucketName = "ob-image/Box_Images",
                CannedACL = S3CannedACL.PublicRead
            };

            var utility = new TransferUtility(s3Client);

            await utility.UploadAsync(request, cancellationToken);

            return $"{_s3Url}{command.DirecotryUploadPath}{command.FileName}";
        }
    }
}
