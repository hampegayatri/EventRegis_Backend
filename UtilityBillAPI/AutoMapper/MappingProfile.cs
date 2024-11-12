using AutoMapper;
using EventManagementAPI.Models;
using EventManagementAPI.DTOs;
using EventManagementAPI.Models.Account;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Example mappings
        CreateMap<Register, RegisterDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<EventDetail, EventDetailDto>().ReverseMap();
        CreateMap<Payment, PaymentDto>().ReverseMap();
        CreateMap<EventRegistration, EventRegistrationDto>().ReverseMap();
        CreateMap<Venue, VenueDto>().ReverseMap();
        CreateMap<Artist, ArtistDto>().ReverseMap();
        CreateMap<Organizer, OrganizerDto>().ReverseMap();
        CreateMap<TicketType, TicketTypeDto>().ReverseMap();
        CreateMap<EventRegistration, EventRegistrationViewModel>()
            .ForMember(dest => dest.IsWaitlisted, opt => opt.MapFrom(src => src.IsWaitlisted));
    }
}
