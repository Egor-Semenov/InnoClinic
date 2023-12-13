using Domain.Models.Enums;

namespace Application.DTOs.Appointments
{
    public sealed class ApproveAppointmentDto
    {
        public int Id { get; set; }
        public AppointmentsStatuses Status { get; set; }
    }
}
