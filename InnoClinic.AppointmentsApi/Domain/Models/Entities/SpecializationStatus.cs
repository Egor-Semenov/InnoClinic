
namespace Domain.Models.Entities
{
    public sealed class SpecializationStatus
    {
        public int StatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Specialization> Specializations { get; set; }
    }
}
