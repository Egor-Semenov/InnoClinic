using Domain.Models.Enums;

namespace Application.DTOs.Services
{
    public sealed class ServiceDto
    {
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public int Specialization { get; set; }
        public ServiceCategories Category { get; set; }
        public ServiceStatuses Status { get; set; }
    }
}
