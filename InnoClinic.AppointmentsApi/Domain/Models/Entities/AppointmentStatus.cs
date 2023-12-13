
namespace Domain.Models.Entities
{
    public sealed class AppointmentStatus
    {
        public int StatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
}
