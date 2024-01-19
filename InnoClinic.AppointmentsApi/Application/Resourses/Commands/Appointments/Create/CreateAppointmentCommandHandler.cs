using Application.DTOs.Appointments;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using FluentValidation;
using MediatR;
using System.Text;

namespace Application.Resourses.Commands.Appointments.Create
{
    public sealed class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, AppointmentDto>
    {
        private readonly IBaseRepository<Appointment> _appointmentsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAppointmentCommand> _validator;

        public CreateAppointmentCommandHandler(IBaseRepository<Appointment> appointmentsRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<CreateAppointmentCommand> validator)
        {
            _appointmentsRepository = appointmentsRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppointmentDto> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
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

            var appointment = new Appointment
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                SpecializationId = request.SpecializationId,
                ServiceId = request.ServiceId,
                OfficeId = request.OfficeId,
                Date = request.Date,
                Time = request.Time,
                Description = request.Description,
                StatusId = (int)AppointmentsStatuses.Pending
            };

            _appointmentsRepository.Create(appointment);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AppointmentDto>(appointment);
        }
    }
}
