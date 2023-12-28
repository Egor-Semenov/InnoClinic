using Application.DTOs.Services;
using Application.Resourses.Commands.Services.Create;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Enums;

namespace Application.Mappers
{
    public sealed class ServicesMapper : Profile
    {
        public ServicesMapper() 
        {
            CreateMap<CreateServiceCommand, Service>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(scr => (int)ServiceStatuses.Active))
                .ForMember(dest => dest.ServiceCategoryId, opt => opt.MapFrom(src => (int)src.Category));

            CreateMap<Service, ServiceDto>()
                .ForMember(dest => dest.Specialization, opt => opt.MapFrom(src => src.SpecializationId))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (ServiceCategories)src.ServiceCategoryId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ServiceCategories)src.StatusId));

            CreateMap<Service, ChangeServiceStatusDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ServiceId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ServiceCategories)src.StatusId));

            CreateMap<Service, UpdateServiceDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ServiceId))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (ServiceCategories)src.ServiceCategoryId));
        }
    }
}
