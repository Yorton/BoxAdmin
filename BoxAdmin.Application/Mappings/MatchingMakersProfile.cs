using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BoxAdmin.Application.Mappings
{
    using BoxAdmin.Domain.Entities.BoxContext;
    using BoxAdmin.Application.Features.MatchingMakers.Queries.GetMatchingMakers;
    using BoxAdmin.Application.Features.MatchingMakers.Queries.GetMatchingMakerById;

    internal class MatchingMakersProfile : Profile
    {
        public MatchingMakersProfile() 
        {
            CreateMap<MatchingMakerListItem, MatchmakerInfo>().ReverseMap();
            CreateMap<GetMatchingMakerByIdResponse, MatchmakerInfo>().ReverseMap();
        }
    }
}
