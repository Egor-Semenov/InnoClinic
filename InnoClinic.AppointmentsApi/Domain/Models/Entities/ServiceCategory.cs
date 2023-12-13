
namespace Domain.Models.Entities
{
    public sealed class ServiceCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
