using Domain.Models.Enums;

namespace Application.DTOs.Services
{
    public sealed class UpdateServiceDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public ServiceCategories Category { get; set; }
        public ServiceStatuses Status { get; set; }
    }
}
