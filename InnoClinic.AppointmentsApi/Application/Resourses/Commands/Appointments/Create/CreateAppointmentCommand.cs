using Application.DTOs.Appointments;
using MediatR;

namespace Application.Resourses.Commands.Appointments.Create
{
    public sealed class CreateAppointmentCommand : IRequest<AppointmentDto>
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int SpecializationId { get; set; }
        public int ServiceId { get; set; }
        public int OfficeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string? Description { get; set; }
    }
}
