using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.MatchingMakers.Commands.MatchingMakerImageSubmit
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using BoxAdmin.Application.DTOs.Settings;
    using BoxAdmin.Application.DTOs.Images;

    public class MatchingMakerImageSubmitCommand : IRequest<MatchingMakerImageSubmitResponse>
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 類型: 1=搭配師照片 2=簽名檔
        /// </summary>
        public int Type { get; set; }
        public IFormFile[] Files { get; set; }
        public MatchingMakerImageSubmitCommand() { }

        public MatchingMakerImageSubmitCommand(Guid id, int type, IFormFile[] files)
        {
            Id = id;
            Type = type;
            Files = files;
        }
    }

    public class MatchingMakerImageSubmitHandler : IRequestHandler<MatchingMakerImageSubmitCommand, MatchingMakerImageSubmitResponse>
    {
        private readonly CommonSettings _commonSettings;
        private readonly AmazonS3Settings _amazonS3Settings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IAwsWrapperService _awsWrapperService;

        public MatchingMakerImageSubmitHandler(
            IOptions<CommonSettings> commonSettings,
            IOptions<AmazonS3Settings> amazonS3Settings,
            IMapper mapper, IBoxDbContext context,
            IAuthenticatedUserService authenticatedUserService,
            IAwsWrapperService awsWrapperService)
        {
            _commonSettings = commonSettings.Value;
            _amazonS3Settings = amazonS3Settings.Value;
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
            _awsWrapperService = awsWrapperService;
        }

        public async Task<MatchingMakerImageSubmitResponse> Handle(MatchingMakerImageSubmitCommand command, CancellationToken cancellationToken)
        {
            var response = new MatchingMakerImageSubmitResponse();

            // validate
            var matchmakerInfo = await _context.MatchmakerInfos.SingleOrDefaultAsync(a => a.Id == command.Id) ??
                throw new ArgumentNullException($"查無資料 id:{command.Id}");

            if (command.Files.Any())
            {
                if (command.Type == 1)
                {
                    #region 搭配師照片
                    var pictureUrl = string.Empty;
                    foreach (var file in command.Files.Take(1))
                    {
                        using var stream = new System.IO.MemoryStream();
                        await file.CopyToAsync(stream, cancellationToken);

                        var uploadImageCommand = new UploadImageCommand()
                        {
                            ImputStream = stream,
                            DirecotryUploadPath = $"{_commonSettings.BoxImageDirectory.MatchingMakerInfoUploadPath}{matchmakerInfo.Id}/",
                            DirecotryPath = $"{_commonSettings.BoxImageDirectory.MatchingMakerInfo}{matchmakerInfo.Id}/",
                            FileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}"
                        };

                        response.ImageUrl.Add(await _awsWrapperService.UploadImageAsync(
                            _amazonS3Settings.AccessKeyId,
                            _amazonS3Settings.SecretAccessKey,
                            uploadImageCommand,
                            cancellationToken));

                        pictureUrl = uploadImageCommand.ToFullPath();
                    }
                    matchmakerInfo.PictureUrl = pictureUrl;
                    #endregion
                }
                else if (command.Type == 2)
                {
                    #region 簽名檔
                    var signatureUrl = new List<string>();
                    foreach (var image in command.Files.Take(2).ToList())
                    {
                        using var stream = new System.IO.MemoryStream();
                        await image.CopyToAsync(stream, cancellationToken);

                        var uploadImageCommand = new UploadImageCommand()
                        {
                            ImputStream = stream,
                            DirecotryUploadPath = $"{_commonSettings.BoxImageDirectory.MatchingMakerInfoUploadPath}{matchmakerInfo.Id}/",
                            DirecotryPath = $"{_commonSettings.BoxImageDirectory.MatchingMakerInfo}{matchmakerInfo.Id}/",
                            FileName = $"sign_{Guid.NewGuid()}{Path.GetExtension(image.FileName)}"
                        };

                        response.ImageUrl.Add(await _awsWrapperService.UploadImageAsync(
                            _amazonS3Settings.AccessKeyId,
                            _amazonS3Settings.SecretAccessKey,
                            uploadImageCommand,
                            cancellationToken));

                        signatureUrl.Add(uploadImageCommand.ToFullPath());
                    }
                    matchmakerInfo.SignatureUrl = signatureUrl.Any() ? string.Join(",", signatureUrl): string.Empty;
                    #endregion
                }

                matchmakerInfo.Modifier = _authenticatedUserService.UserId;
                matchmakerInfo.ModifyDate = DateTime.Now;
                await _context.SaveChangesAsync(cancellationToken);
            }

            return response;
        }
    }

    public class MatchingMakerImageSubmitResponse
    {
        public List<string> ImageUrl { get; set; } = new List<string>();
    }
}
