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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePatientCommandHandler(IBaseRepository<Patient> patientsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _patientsRepository = patientsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdatePatientDto> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
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

            _patientsRepository.Update(patient);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UpdatePatientDto>(patient);
        }
    }
}
