using Domain.Models.Enums;

namespace Application.DTOs.Appointments
{
    public sealed class AppointmentDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int SpecializationId { get; set; }
        public int ServiceId { get; set; }
        public int OfficeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public AppointmentsStatuses Status { get; set; }
    }
}
