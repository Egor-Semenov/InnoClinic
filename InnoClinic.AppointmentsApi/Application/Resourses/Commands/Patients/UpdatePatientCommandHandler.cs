using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Patients
{
    public sealed class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Patient>
    {
        private readonly IBaseRepository<Patient> _patientsRepository;

        public UpdatePatientCommandHandler(IBaseRepository<Patient> patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<Patient> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientsRepository.FindByCondition(x => x.FirstName == request.FirstName, false).FirstOrDefaultAsync();

            if (patient is null)
            {
                throw new NotFoundException($"Patient is not found.");
            }

            patient.FirstName = request.FirstName;
            patient.LastName = request.LastName;
            patient.MiddleName = request.MiddleName;
            patient.PhoneNumber = request.PhoneNumber;
            patient.BirthDate = request.BirthDate;
            patient.PhotoFilePath = request.PhotoFilePath;

            await _patientsRepository.Update(patient);

            return patient;
        }
    }
}
