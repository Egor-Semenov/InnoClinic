using Domain.Models.Enums;

namespace Domain.RequestFeatures
{
    public sealed class SpecializationParameters
    {
        public SpecializationStatuses SpecializationStatus { get; set; }
        public string? SearchTerm { get; set; }
    }
}
