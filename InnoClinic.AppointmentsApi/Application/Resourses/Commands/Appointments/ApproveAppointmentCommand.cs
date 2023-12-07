using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Appointments
{
    public sealed class ApproveAppointmentCommand : IRequest<Appointment>
    {
        public int Id { get; set; }
    }
}
