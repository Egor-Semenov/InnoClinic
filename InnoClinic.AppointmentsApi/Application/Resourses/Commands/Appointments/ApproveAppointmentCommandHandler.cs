using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Appointments
{
    public sealed class ApproveAppointmentCommandHandler : IRequestHandler<ApproveAppointmentCommand, Appointment>
    {
        private readonly IBaseRepository<Appointment> _appointmentRepository;

        public ApproveAppointmentCommandHandler(IBaseRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> Handle(ApproveAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();
            if (appointment is null)
            {
                throw new NotFoundException($"Appointment with id {request.Id} is not found.");
            }

            if (appointment.StatusId == (int)AppointmentsStatuses.Approved)
            {
                throw new BadRequestException($"Appointment with id {request.Id} has approved status already.");
            }

            appointment.StatusId = (int)AppointmentsStatuses.Approved;
            
            await _appointmentRepository.Update(appointment);
            return appointment;
        }
    }
}
