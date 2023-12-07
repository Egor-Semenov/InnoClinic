using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Patients
{
    public sealed class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Patient>
    {
        private readonly IBaseRepository<Patient> _patientsRepository;

        public DeletePatientCommandHandler(IBaseRepository<Patient> patientsRepository)
        {
            _patientsRepository = patientsRepository;
        }

        public async Task<Patient> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();
            if (patient is null) 
            {
                throw new NotFoundException($"Patient with id: {request.Id} is not found.");
            }

            await _patientsRepository.Delete(patient);
            return patient;
        }
    }
}
