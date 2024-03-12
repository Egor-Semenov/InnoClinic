
namespace Domain.Models.Entities
{
    public sealed class Doctor
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int SpecializationId { get; set; }
        public int OfficeId { get; set; }
        public DateTime CareerStartYear { get; set; }
        public int StatusId { get; set; }
        public string? PhotoFilePath { get; set; }

        public Specialization Specialization { get; set; }
        public DoctorStatus Status { get; set; }
        public Office Office { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
