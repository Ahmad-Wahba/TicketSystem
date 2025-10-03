using AutoMapper;
using TicketSystem.Core.DTOs;
using TicketSystem.Core.Models;

namespace TicketSystem.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Ticket, TicketViewDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()))
                .ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.AssignedToITMemberName, opt => opt.MapFrom(src => src.Engineer.FullName));


            CreateMap<TicketUpdateDto, Ticket>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()));


            CreateMap<User, UserCreateDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Departments.Name));


            CreateMap<User, UserViewDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Departments.Name));
        }
    }
}