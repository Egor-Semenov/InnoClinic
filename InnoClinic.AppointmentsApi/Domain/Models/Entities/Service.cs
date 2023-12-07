
namespace Domain.Models.Entities
{
    public sealed class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int ServiceCategoryId { get; set; }
        public double Price { get; set; }
        public int StatusId { get; set; }

        public ServiceCategory ServiceCategory { get; set; }
        public ServiceStatus Status { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
