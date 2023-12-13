
namespace Domain.Models.Entities
{
    public sealed class OfficeStatus
    {
        public int StatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Office> Offices { get; set; }
    }
}
