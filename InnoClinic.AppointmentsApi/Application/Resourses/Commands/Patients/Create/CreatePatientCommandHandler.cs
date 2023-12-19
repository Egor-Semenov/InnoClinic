using Application.DTOs.Patients;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using System.Text;

namespace Application.Resourses.Commands.Patients.Create
{
    public sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, PatientDto>
    {
        private readonly IBaseRepository<Patient> _patientsRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreatePatientCommand> _validator;

        public CreatePatientCommandHandler(IBaseRepository<Patient> patientsRepository, IMapper mapper, IValidator<CreatePatientCommand> validator)
        {
            _patientsRepository = patientsRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<PatientDto> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var stringBuilder = new StringBuilder();
                foreach (var error in validationResult.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }

                throw new BadRequestException(stringBuilder.ToString());
            }

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
            return _mapper.Map<PatientDto>(patient);
        }
    }
}
