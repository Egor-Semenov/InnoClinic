﻿using Application.DTOs.Services;
using Application.Resourses.Commands.Services.Create;
using AutoMapper;
using Domain.Models.Entities;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (ServiceCategories)src.ServiceCategoryId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ServiceCategories)src.StatusId));

            CreateMap<Service, ChangeServiceStatusDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ServiceCategories)src.StatusId));

            CreateMap<Service, UpdateServiceDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => (ServiceCategories)src.ServiceCategoryId));
        }
    }
}
