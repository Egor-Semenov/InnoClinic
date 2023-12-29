using Domain.Models.Enums;

namespace Domain.RequestFeatures
{
    public sealed class OfficeParameters
    {
        public OfficeStatuses OfficeStatus { get; set; }
        public string? SearchTerm { get; set; }
    }
}
