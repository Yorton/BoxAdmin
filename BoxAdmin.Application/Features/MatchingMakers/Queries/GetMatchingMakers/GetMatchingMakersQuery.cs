using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using MediatR;

using BoxAdmin.Application.DTOs.Settings;
using BoxAdmin.Application.Interfaces.Contexts;

namespace BoxAdmin.Application.Features.MatchingMakers.Queries.GetMatchingMakers
{
    public class GetMatchingMakersQuery : IRequest<GetMatchingMakersResponse>
    {
    }

    public class GetMatchingMakersQueryHandler : IRequestHandler<GetMatchingMakersQuery, GetMatchingMakersResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBoxDbContext _context;
        private readonly CommonSettings _commonSettings;

        public GetMatchingMakersQueryHandler(IMapper mapper, IBoxDbContext context, IOptions<CommonSettings> commonSettings)
        {
            _mapper = mapper;
            _context = context;
            _commonSettings = commonSettings.Value;
        }

        public async Task<GetMatchingMakersResponse> Handle(GetMatchingMakersQuery command, CancellationToken cancellationToken)
        {
            var matchmakers = await _context.MatchmakerInfos.ToListAsync();

            var mappedMatchingmakers = _mapper.Map<List<MatchingMakerListItem>>(matchmakers);

            var matchmakerIds = mappedMatchingmakers.Select(a => a.Id).ToList();

            // 九大風格搭配盒數
            var boxCountIncludeStyleQuery = await (
                from a in _context.Reservations
                join g in _context.ReservationLineItemGroups on a.Id equals g.ReservationId
                join s in _context.StyleBookConditions on g.StyleId equals s.Id
                where s.Type == 1 && matchmakerIds.Contains(a.MatchmakerId)
                select new { a.MatchmakerId, a.Id, g.StyleId, s.Name })
                .Distinct()
                .ToListAsync();

            var boxTotalCountQuery = await _context.Reservations
                .Where(a => matchmakerIds.Contains(a.MatchmakerId))
                .GroupBy(g => g.MatchmakerId)
                .Select(g => new { MatchmakerId = g.Key, Count = g.Count() })
                .ToListAsync();

            foreach (var mapped in mappedMatchingmakers)
            {
                // 搭配盒數
                var matchingmakerBoxTotalCountQuery = boxTotalCountQuery.SingleOrDefault(a => a.MatchmakerId == mapped.Id);
                mapped.BoxCount = matchingmakerBoxTotalCountQuery?.Count ?? 0;

                // 風格搭配盒數
                var matchingmakerBoxCountIncludeStyleQuery = boxCountIncludeStyleQuery.Where(a => a.MatchmakerId == mapped.Id).ToList();
                mapped.MatchingCounts = matchingmakerBoxCountIncludeStyleQuery.GroupBy(g => new { g.StyleId, g.Name })
                    .Select(s => new MatchingCount
                    {
                        StyleId = s.Key.StyleId.Value,
                        Title = s.Key.Name,
                        Count = s.Count()
                    }).ToList();

                // 搭配師圖片
                var pictureUrl = matchmakers.FirstOrDefault(x => x.Id == mapped.Id)?.PictureUrl ?? "";
                mapped.Pictures = pictureUrl.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(img => $"{_commonSettings.BoxImageUrl}{img}")
                    .ToList();
            }

            return new GetMatchingMakersResponse() { MatchingMakers = mappedMatchingmakers };
        }
    }
}
