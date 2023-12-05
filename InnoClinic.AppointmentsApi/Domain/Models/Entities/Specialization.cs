
namespace Domain.Models.Entities
{
    public sealed class Specialization
    {
        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
