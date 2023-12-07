
namespace Domain.Models.Entities
{
    public sealed class DoctorStatus
    {
        public int StatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
    }
}
