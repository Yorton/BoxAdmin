using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BoxAdmin.Application.Mappings
{
    using BoxAdmin.Domain.Entities.BoxContext;
    using BoxAdmin.Application.Features.Subscribes.Queries.GetSubscribeById;

    internal class SubscribesProfile : Profile
    {
        public SubscribesProfile()
        {
            CreateMap<GetSubscribeByIdResponse, Subscribe>()
                .ReverseMap();
        }
    }
}
