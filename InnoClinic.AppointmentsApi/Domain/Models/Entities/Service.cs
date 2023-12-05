
namespace Domain.Models.Entities
{
    public sealed class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public double ServiceCost { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
