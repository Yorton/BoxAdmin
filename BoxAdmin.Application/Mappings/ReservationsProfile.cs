using AutoMapper;

namespace BoxAdmin.Application.Mappings
{
    public class ReservationsProfile : Profile
    {
        public ReservationsProfile()
        {
            CreateMap<Features.Reservations.Queries.Get.ReservationItem, Domain.Entities.BoxContext.Reservation>().ReverseMap();
            CreateMap<Features.Reservations.Queries.GetById.GetReservationByIdResponse, Domain.Entities.BoxContext.Reservation>().ReverseMap();
            CreateMap<Features.Reservations.Queries.GetById.ReservationLineItemGroup, Domain.Entities.BoxContext.ReservationLineItemGroup>().ReverseMap();
            CreateMap<Features.Reservations.Queries.GetById.ReservationLineItem, Domain.Entities.BoxContext.ReservationLineItem>().ReverseMap();
            CreateMap<Features.Reservations.Queries.GetById.ReservationRecipient, Domain.Entities.BoxContext.ReservationRecipient>().ReverseMap();
        }
    }
}

