using Application.DTOs.Doctors;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Doctors.Update
{
    public sealed class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, UpdateDoctorDto>
    {
        private readonly IBaseRepository<Doctor> _doctorsRepository;
        private readonly IMapper _mapper;

        public UpdateDoctorCommandHandler(IBaseRepository<Doctor> doctorsRepository, IMapper mapper)
        {
            _doctorsRepository = doctorsRepository;
            _mapper = mapper;
        }

        public async Task<UpdateDoctorDto> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorsRepository.FindByCondition(x => x.Email == request.Email, false).FirstOrDefaultAsync();

            if (doctor is null)
            {
                throw new NotFoundException($"Doctor with email: {request.Email} is not found.");
            }

            doctor.FirstName = request.FirstName;
            doctor.LastName = request.LastName;
            doctor.MiddleName = request.MiddleName;
            doctor.BirthDate = request.BirthDate;
            doctor.CareerStartYear = request.CareerStartYear;
            doctor.OfficeId = request.OfficeId;
            doctor.SpecializationId = request.SpecializationId;
            doctor.PhotoFilePath = request.PhotoFilePath;
            doctor.StatusId = (int)request.Status;

            await _doctorsRepository.Update(doctor);
            return _mapper.Map<UpdateDoctorDto>(doctor);
        }
    }
}
