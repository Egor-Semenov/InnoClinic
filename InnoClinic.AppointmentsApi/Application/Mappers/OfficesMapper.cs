using Application.DTOs.Offices;
using Application.Resourses.Commands.Offices.Create;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Enums;

namespace Application.Mappers
{
    public sealed class OfficesMapper : Profile
    {
        public OfficesMapper() 
        {
            CreateMap<CreateOfficeCommand, Office>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => (int)OfficeStatuses.Active));

            CreateMap<Office, OfficeDto>()
                .ForMember(dest => dest.OfficeAddress, opt => opt.MapFrom(src => $"{src.City}, {src.Street} - {src.HouseNumber}, office: {src.OfficeNumber}"));

            CreateMap<Office, UpdateOfficeDto>()
                .ForMember(dest => dest.OfficeAddress, opt => opt.MapFrom(src => $"{src.City}, {src.Street} - {src.HouseNumber}, office: {src.OfficeNumber}"));

            CreateMap<Office, ChangeOfficeStatusDto>();
        }
    }
}
