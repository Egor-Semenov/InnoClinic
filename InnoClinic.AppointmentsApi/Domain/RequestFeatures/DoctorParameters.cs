using Domain.Models.Enums;

namespace Domain.RequestFeatures
{
    public sealed class DoctorParameters : RequestParameters
    {
        public int SpecializationType { get; set; }
        public int OfficeId { get; set; }
        public DoctorsStatuses DoctorStatus { get; set; }
        public string? SearchTerm { get; set; }
    }
}
