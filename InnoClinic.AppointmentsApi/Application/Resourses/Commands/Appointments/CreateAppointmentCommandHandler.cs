using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Appointments
{
    public sealed class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, Appointment>
    {
        private readonly IBaseRepository<Appointment> _appointmentsRepository;

        public CreateAppointmentCommandHandler(IBaseRepository<Appointment> appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task<Appointment> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = new Appointment()
            {
                PatientId = request.PatientId,
                DoctorId = request.DoctorId,
                SpecializationId = (int)request.SpecializationType,
                ServiceId = (int)request.ServiceType,
                Office = request.OfficeId,
                Date = request.Date,
                Time = request.Time,
                Description = request.Description,
                StatusId = (int)AppointmentsStatuses.Pending
            };

            await _appointmentsRepository.Create(appointment);
            return appointment;
        }
    }
}
