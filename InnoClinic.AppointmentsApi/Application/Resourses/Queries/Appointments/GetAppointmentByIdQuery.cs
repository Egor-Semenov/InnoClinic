using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Queries.Appointments
{
    public sealed class GetAppointmentByIdQuery : IRequest<Appointment>
    {
        public int Id { get; set; }
    }
}
