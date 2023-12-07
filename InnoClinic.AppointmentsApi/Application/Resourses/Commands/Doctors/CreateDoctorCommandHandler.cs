using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Doctors
{
    public sealed class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, Doctor>
    {
        private readonly IBaseRepository<Doctor> _doctorsRepository;
        private readonly IBaseRepository<Specialization> _specializationsRepository;

        public CreateDoctorCommandHandler(IBaseRepository<Doctor> doctorsRepository, IBaseRepository<Specialization> specializationsRepository)
        {
            _doctorsRepository = doctorsRepository;
            _specializationsRepository = specializationsRepository;
        }

        public async Task<Doctor> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var specialization = await _specializationsRepository.FindByCondition(x => x.SpecializationName == request.Specialization, false).FirstOrDefaultAsync();
            
            if (specialization is null) 
            {
                throw new NotFoundException($"Specialization {request.Specialization} doesn't exist in the system.");
            }

            var doctor = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                BirthDate = request.BirthDate,
                Email = request.Email,
                SpecializationId = specialization!.SpecializationId,
                OfficeId = request.OfficeId,
                CareerStartYear = request.CareerStartYear,
                StatusId = (int)request.Status,
                PhotoFilePath = request.PhotoFilePath
            };

            await _doctorsRepository.Create(doctor);
            return doctor;
        }
    }
}
