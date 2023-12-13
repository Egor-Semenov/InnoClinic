using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Appointments.Delete
{
    public sealed class DeleteAppointmentCommand : IRequest<Appointment>
    {
        public int Id { get; set; }
    }
}
