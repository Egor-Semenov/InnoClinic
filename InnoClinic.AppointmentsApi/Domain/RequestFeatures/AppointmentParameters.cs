using Domain.Models.Enums;

namespace Domain.RequestFeatures
{
    public sealed class AppointmentParameters : RequestParameters
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int SpecializationId { get; set; }
        public int ServiceId { get; set; }
        public int OfficeId { get; set; }
        public AppointmentsStatuses AppointmentStatus { get; set; }
    }
}
