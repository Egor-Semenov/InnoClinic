using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Doctors
{
    public sealed class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, Doctor>
    {
        private readonly IBaseRepository<Doctor> _doctorsRepository;

        public UpdateDoctorCommandHandler(IBaseRepository<Doctor> doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        public async Task<Doctor> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
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
            doctor.SpecializationId = (int)request.Specialization;
            doctor.PhotoFilePath = request.PhotoFilePath;
            doctor.StatusId = (int)request.Status;

            await _doctorsRepository.Update(doctor);
            return doctor;
        }
    }
}
