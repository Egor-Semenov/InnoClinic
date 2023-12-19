using Application.DTOs.Patients;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Patients.Create
{
    public sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientDto>
    {
        private readonly IBaseRepository<Patient> _patientsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePatientCommandHandler(IBaseRepository<Patient> patientsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _patientsRepository = patientsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
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

            _patientsRepository.Create(patient);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PatientDto>(patient);
        }
    }
}
