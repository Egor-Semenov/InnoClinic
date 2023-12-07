using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Patients
{
    public sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Patient>
    {
        private readonly IBaseRepository<Patient> _patientsRepository;

        public CreatePatientCommandHandler(IBaseRepository<Patient> patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<Patient> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Patient
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                PhoneNumber = request.PhoneNumber,
                BirthDate = request.BirthDate,
                PhotoFilePath = request.PhotoFilePath
            };

            await _patientsRepository.Create(patient);
            return patient;
        }
    }
}
