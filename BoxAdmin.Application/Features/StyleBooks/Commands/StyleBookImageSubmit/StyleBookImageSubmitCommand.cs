using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.StyleBooks.Commands.StyleBookImageSubmit
{
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;
    using BoxAdmin.Application.DTOs.Settings;
    using BoxAdmin.Application.DTOs.Images;

    public class StyleBookImageSubmitCommand : IRequest<StyleBookImageSubmitResponse>
    {
        public Guid Id { get; set; }
        public Stream ImageStream { get; set; }
        public string SourceFileName { get; set; }
        public StyleBookImageSubmitCommand() { }
        public StyleBookImageSubmitCommand(Guid id, Stream imageStream, string sourceFileName)
        {
            Id = id;
            ImageStream = imageStream;
            SourceFileName = sourceFileName;
        }
    }

    public class StyleBookImageSubmitHandler : IRequestHandler<StyleBookImageSubmitCommand, StyleBookImageSubmitResponse>
    {
        private readonly CommonSettings _commonSettings;
        private readonly AmazonS3Settings _amazonS3Settings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;
        private readonly IAwsWrapperService _awsWrapperService;

        public StyleBookImageSubmitHandler(
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

        public async Task<StyleBookImageSubmitResponse> Handle(StyleBookImageSubmitCommand command, CancellationToken cancellationToken)
        {
            var response = new StyleBookImageSubmitResponse();

            // validate
            var styleBook = await _context.StyleBooks.SingleOrDefaultAsync(a => a.Id == command.Id) ??
                throw new ArgumentNullException($"查無資料 id:{command.Id}");

            var uploadImageCommand = new UploadImageCommand()
            {
                ImputStream = command.ImageStream,
                DirecotryPath = $"{_commonSettings.BoxImageDirectory.StyleBook}{styleBook.Id}/",
                DirecotryUploadPath = $"{_commonSettings.BoxImageDirectory.StyleBookUploadPath}{styleBook.Id}/",
                FileName = $"{Guid.NewGuid()}{Path.GetExtension(command.SourceFileName)}"
            };

            response.ImageUrl = await _awsWrapperService.UploadImageAsync(
                _amazonS3Settings.AccessKeyId,
                _amazonS3Settings.SecretAccessKey,
                uploadImageCommand,
                cancellationToken);

            styleBook.ImageUrl = uploadImageCommand.DirecotryPath + uploadImageCommand.FileName;
            await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
