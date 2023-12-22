using Application.DTOs.Doctors;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Doctors.ChangeStatus
{
    public sealed class ChangeDoctorStatusCommandHandler : IRequestHandler<ChangeDoctorStatusCommand, ChangeDoctorStatusDto>
    {
        private readonly IBaseRepository<Doctor> _doctorsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        IValidator<ChangeDoctorStatusCommand> _validator;

        public ChangeDoctorStatusCommandHandler(IBaseRepository<Doctor> doctorsRepository, IMapper mapper, IValidator<ChangeDoctorStatusCommand> validator, IUnitOfWork unitOfWork)
        {
            _doctorsRepository = doctorsRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ChangeDoctorStatusDto> Handle(ChangeDoctorStatusCommand request, CancellationToken cancellationToken)
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

            var doctor = await _doctorsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();

            if (doctor is null)
            {
                throw new NotFoundException($"Doctor with id: {request.Id} is not found.");
            }

            if (doctor.StatusId == (int)request.Status)
            {
                throw new BadRequestException($"Doctor with id: {request.Id} has {request.Status} status already.");
            }

            doctor.StatusId = (int)request.Status;

            _doctorsRepository.Update(doctor);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ChangeDoctorStatusDto>(doctor);
        }
    }
}
