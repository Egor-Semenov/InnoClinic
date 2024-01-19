
namespace Domain.Models.Entities
{
    public sealed class Specialization
    {
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }
        public int StatusId { get; set; }

        public SpecializationStatus Status { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
