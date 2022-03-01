using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.MatchingMakers.Commands.MatchingMakerSubmit
{
    using BoxAdmin.Framework.Results;
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.Interfaces.Shared;
    using BoxAdmin.Domain.Entities.BoxContext;

    public class MatchingMakerSubmitCommand : IRequest<MatchingMakerSubmitResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 自我介紹
        /// </summary>
        public string SelfIntroduction { get; set; }
        public string LikeStyle { get; set; }
        public string Slogan { get; set; }
        public List<string> PictureUrl { get; set; } = new List<string>();
        public List<string> SignatureUrl { get; set; } = new List<string>();
    }

    public class MatchingMakerSubmitCommandHandler : IRequestHandler<MatchingMakerSubmitCommand, MatchingMakerSubmitResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public MatchingMakerSubmitCommandHandler(IMapper mapper, IBoxDbContext context, IAuthenticatedUserService authenticatedUserService)
        {
            _mapper = mapper;
            _context = context;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<MatchingMakerSubmitResponse> Handle(MatchingMakerSubmitCommand command, CancellationToken cancellationToken)
        {
            var response = new MatchingMakerSubmitResponse();
            MatchmakerInfo matchmaker = null;
            var isNew = false;
            if ((command.Id ?? "") == string.Empty)
            {
                isNew = true;
            }
            else
            {
                var matchmakerId = Guid.Parse(command.Id ?? "");
                matchmaker = await _context.MatchmakerInfos.SingleOrDefaultAsync(a => a.Id == matchmakerId, cancellationToken)
                    ?? throw new Exceptions.ApiException($"MatchmakerInfo '{command.Id}' is not found");
            }

            if (isNew)
            {
                matchmaker = new MatchmakerInfo()
                {
                    Id = Guid.NewGuid(),
                    Name = command.Name,
                    PictureUrl = string.Empty,
                    SignatureUrl = string.Empty,
                    SelfIntroduction = command.SelfIntroduction,
                    LikeStyle = command.LikeStyle,
                    Slogan = command.Slogan,
                    Creator = _authenticatedUserService.UserId,
                    CreatedDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    Modifier = _authenticatedUserService.UserId,
                };

                _context.MatchmakerInfos.Add(matchmaker);
            }
            else
            {
                matchmaker.Name = command.Name;

                if (!command.PictureUrl.Any())
                    matchmaker.PictureUrl = string.Empty;

                if (!command.SignatureUrl.Any())
                    matchmaker.SignatureUrl = string.Empty;

                matchmaker.SelfIntroduction = command.SelfIntroduction;
                matchmaker.LikeStyle = command.LikeStyle;
                matchmaker.Slogan = command.Slogan;
                matchmaker.ModifyDate = DateTime.Now;
                matchmaker.Modifier = _authenticatedUserService.UserId;
            }

            await _context.SaveChangesAsync(cancellationToken);

            response.Id = matchmaker.Id;

            return response;
        }
    }
}
