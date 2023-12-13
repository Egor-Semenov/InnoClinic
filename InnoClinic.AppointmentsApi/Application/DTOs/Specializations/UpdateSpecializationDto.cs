using Domain.Models.Enums;

namespace Application.DTOs.Specializations
{
    public sealed class UpdateSpecializationDto
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; }
        public SpecializationStatuses Status { get; set; }
    }
}
