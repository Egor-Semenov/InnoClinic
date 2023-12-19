using Application.DTOs.Patients;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Patients.Update
{
    public sealed class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, UpdatePatientDto>
    {
        private readonly IBaseRepository<Patient> _patientsRepository;
        private readonly IMapper _mapper;

        public UpdatePatientCommandHandler(IBaseRepository<Patient> patientsRepository, IMapper mapper)
        {
            _patientsRepository = patientsRepository;
            _mapper = mapper;
        }

        public async Task<UpdatePatientDto> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();

            if (patient is null)
            {
                throw new NotFoundException($"Patient with id: {request.Id} is not found.");
            }

            patient.FirstName = request.FirstName;
            patient.LastName = request.LastName;
            patient.MiddleName = request.MiddleName;
            patient.PhoneNumber = request.PhoneNumber;
            patient.BirthDate = request.BirthDate;
            patient.PhotoFilePath = request.PhotoFilePath;

            await _patientsRepository.Update(patient);

            return _mapper.Map<UpdatePatientDto>(patient);
        }
    }
}
