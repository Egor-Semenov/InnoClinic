using Application.DTOs.Patients;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Patients.Update
{
    public sealed class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, UpdatePatientDto>
    {
        private readonly IBaseRepository<Patient> _patientsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdatePatientCommand> _validator;

        public UpdatePatientCommandHandler(IBaseRepository<Patient> patientsRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<UpdatePatientCommand> validator)
        {
            _patientsRepository = patientsRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdatePatientDto> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
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

            _patientsRepository.Update(patient);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UpdatePatientDto>(patient);
        }
    }
}
