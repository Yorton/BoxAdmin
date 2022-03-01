using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using AutoMapper;
using MediatR;

namespace BoxAdmin.Application.Features.MatchingMakers.Queries.GetMatchingMakerById
{
    using BoxAdmin.Framework.Results;
    using BoxAdmin.Application.Interfaces.Contexts;
    using BoxAdmin.Application.DTOs.Settings;

    public class GetMatchingMakerByIdQuery : IRequest<GetMatchingMakerByIdResponse>
    {
        public Guid Id { get; set; }
        public GetMatchingMakerByIdQuery() { }
        public GetMatchingMakerByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    public class GetMatchingMakerByIdQueryHandler : IRequestHandler<GetMatchingMakerByIdQuery, GetMatchingMakerByIdResponse>
    {
        private readonly CommonSettings _commonSettings;
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;

        public GetMatchingMakerByIdQueryHandler(
            IOptions<CommonSettings> commonSettings,
            IMapper mapper, IBoxDbContext context)
        {
            _commonSettings = commonSettings.Value;
            _mapper = mapper;
            _context = context;
        }

        public async Task<GetMatchingMakerByIdResponse> Handle(GetMatchingMakerByIdQuery command, CancellationToken cancellationToken)
        {
            var matchmakerInfo = await _context.MatchmakerInfos.SingleOrDefaultAsync(a => a.Id == command.Id, cancellationToken);

            var mappedMatchingMaker = _mapper.Map<GetMatchingMakerByIdResponse>(matchmakerInfo);

            // 搭配師照片
            mappedMatchingMaker.PictureUrl = new List<string>();
            if (!string.IsNullOrEmpty(matchmakerInfo.PictureUrl))
            {
                var pictureUrls = matchmakerInfo.PictureUrl.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                mappedMatchingMaker.PictureUrl = pictureUrls.Where(s => !string.IsNullOrEmpty(s))
                    .Select(imageurl => $"{_commonSettings.BoxImageUrl}{imageurl}")
                    .ToList();
            }

            // 簽名檔
            mappedMatchingMaker.SignatureUrl = new List<string>();
            if (!string.IsNullOrEmpty(matchmakerInfo.SignatureUrl))
            {
                var signatureUrls = matchmakerInfo.SignatureUrl.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                mappedMatchingMaker.SignatureUrl = signatureUrls.Where(s => !string.IsNullOrEmpty(s))
                    .Select(imageurl => $"{_commonSettings.BoxImageUrl}{imageurl}")
                    .ToList();
            }

            // 九大風格搭配盒數
            var boxCountQuery = await (
                from a in _context.Reservations
                join g in _context.ReservationLineItemGroups on a.Id equals g.ReservationId
                join s in _context.StyleBookConditions on g.StyleId equals s.Id
                where s.Type == 1 && a.MatchmakerId == command.Id
                select new { a.Id, g.StyleId, s.Name })
                .Distinct()
                .ToListAsync();

            mappedMatchingMaker.MatchingCounts = boxCountQuery.GroupBy(g => new { g.StyleId, g.Name })
                .Select(s => new GetMatchingMakerById_MatchingCount
                {
                    StyleId = s.Key.StyleId.Value,
                    Title = s.Key.Name,
                    Count = s.Count()
                }).ToList();


            return mappedMatchingMaker;
        }
    }
}
