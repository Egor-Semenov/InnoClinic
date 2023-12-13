using Domain.Models.Enums;

namespace Application.DTOs.Specializations
{
    public sealed class SpecializationDto
    {
        public string SpecializationName { get; set; }
        public SpecializationStatuses Status { get; set; }
    }
}
