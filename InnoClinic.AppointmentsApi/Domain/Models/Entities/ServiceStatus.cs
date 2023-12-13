
namespace Domain.Models.Entities
{
    public sealed class ServiceStatus
    {
        public int StatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
