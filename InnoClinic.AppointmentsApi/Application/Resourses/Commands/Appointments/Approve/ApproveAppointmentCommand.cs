using Application.DTOs.Appointments;
using MediatR;

namespace Application.Resourses.Commands.Appointments.Approve
{
    public sealed class ApproveAppointmentCommand : IRequest<ApproveAppointmentDto>
    {
        public int Id { get; set; }
    }
}
