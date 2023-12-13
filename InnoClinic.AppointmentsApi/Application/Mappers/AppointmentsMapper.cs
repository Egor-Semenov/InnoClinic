using Application.DTOs.Appointments;
using Application.Resourses.Commands.Appointments.Create;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Enums;

namespace Application.Mappers
{
    public sealed class AppointmentsMapper : Profile
    {
        public AppointmentsMapper() 
        {
            CreateMap<CreateAppointmentCommand, Appointment>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => (int)AppointmentsStatuses.Pending));

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (AppointmentsStatuses)src.StatusId));

            CreateMap<Appointment, ApproveAppointmentDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (AppointmentsStatuses)src.StatusId));

            CreateMap<Appointment, DeleteAppointmentDto>();
        }
    }
}
