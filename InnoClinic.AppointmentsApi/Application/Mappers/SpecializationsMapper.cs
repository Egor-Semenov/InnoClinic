using Application.DTOs.Specializations;
using Application.Resourses.Commands.Specializations.Create;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Enums;

namespace Application.Mappers
{
    public sealed class SpecializationsMapper : Profile
    {
        public SpecializationsMapper() 
        {
            CreateMap<CreateSpecializationCommand, Specialization>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => (int)SpecializationStatuses.Active));

            CreateMap<Specialization, SpecializationDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.StatusId));

            CreateMap<Specialization, ChangeSpecializationStatusDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.StatusId));

            CreateMap<Specialization, UpdateSpecializationDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.StatusId));
        }
    }
}
