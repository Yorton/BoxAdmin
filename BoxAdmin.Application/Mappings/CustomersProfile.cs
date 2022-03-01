using AutoMapper;

namespace BoxAdmin.Application.Mappings
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Domain.Entities.BoxContext.CustomerInfo, Features.Customers.Queries.GetCustomerById.GetCustomerByIdResponse>()
                .ForMember(x => x.Id, y => y.MapFrom(o => o.CustomerId))
                .ReverseMap();
        }
    }
}