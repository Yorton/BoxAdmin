using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BoxAdmin.Application.Mappings
{
    using BoxAdmin.Domain.Entities.BoxContext;
    using GetStyleBooks = BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBooks;
    using GetStyleBookById = BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBookById;
    using GetStyleBookConditions = BoxAdmin.Application.Features.StyleBooks.Queries.GetStyleBookConditions;

    internal class StyleBooksProfile : Profile
    {
        public StyleBooksProfile()
        {
            CreateMap<GetStyleBooks.StyleBookListItem, StyleBook>().ReverseMap();

            CreateMap<StyleBook, GetStyleBookById.GetStyleBookByIdResponse>()
                .ForMember(x => x.CreatedBy, y => y.MapFrom(o => o.Creator))
                .ForMember(x => x.CreatedAt, y => y.MapFrom(o => o.CreatedDate))
                .ReverseMap();

            CreateMap<GetStyleBookById.StyleBookProduct, StyleBookDetail>()
                .ReverseMap();

            CreateMap<GetStyleBookById.Matchmaker, MatchmakerInfo>()
                .ReverseMap();

            CreateMap<GetStyleBookConditions.StyleBookConditionItem, StyleBookCondition>()
                .ForMember(x => x.Name, y => y.MapFrom(o => o.Title))
                .ReverseMap();
        }
    }
}
