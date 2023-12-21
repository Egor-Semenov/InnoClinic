using Application.DTOs.Doctors;
using Application.DTOs.Patients;
using Application.DTOs.Receptionists;
using Application.Resourses.Commands.Doctors.Create;
using Application.Resourses.Commands.Patients.Create;
using Application.Resourses.Commands.Receptionists.Create;
using AutoMapper;
using Domain.Models.Entities;

namespace Application.Mappers
{
    public sealed class UserProfilesMapper : Profile
    {
        public UserProfilesMapper()
        {
            CreateMap<CreateDoctorCommand, Doctor>()
                .ForMember(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status));

            CreateMap<Doctor, DoctorDto>()
                .ForMember(dest => dest.Expirience, opt => opt.MapFrom(src => $"Expirience: {DateTime.Now.Year - src.CareerStartYear.Year + 1} years."));

            CreateMap<Doctor, UpdateDoctorDto>()
                .ForMember(dest => dest.Expirience, opt => opt.MapFrom(src => $"Expirience: {DateTime.Now.Year - src.CareerStartYear.Year + 1} years."));

            CreateMap<Doctor, ChangeDoctorStatusDto>();

            CreateMap<CreatePatientCommand, Patient>();
            CreateMap<Patient, PatientDto>();
            CreateMap<Patient, DeletePatientDto>();
            CreateMap<Patient, UpdatePatientDto>();

            CreateMap<CreateReceptionistCommand, Receptionist>();
            CreateMap<Receptionist, ReceptionistDto>();
            CreateMap<Receptionist, DeleteReceptionistDto>();
            CreateMap<Receptionist, UpdateReceptionistDto>();
        }
    }
}
