using Domain.Models.Enums;

namespace Domain.RequestFeatures
{
    public sealed class ServiceParameters
    {
        public int SpecializationId { get; set; }
        public ServiceCategories ServiceCategory { get; set; }
        public ServiceStatuses ServiceStatus { get; set; }
        public string? SearchTerm { get; set; }
    }
}
