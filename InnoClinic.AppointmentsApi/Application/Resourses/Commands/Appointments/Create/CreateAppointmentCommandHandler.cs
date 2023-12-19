using Application.DTOs.Appointments;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Appointments.Create
{
    public sealed class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, AppointmentDto>
    {
        private readonly IBaseRepository<Appointment> _appointmentsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAppointmentCommandHandler(IBaseRepository<Appointment> appointmentsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _appointmentsRepository = appointmentsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AppointmentDto> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
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
