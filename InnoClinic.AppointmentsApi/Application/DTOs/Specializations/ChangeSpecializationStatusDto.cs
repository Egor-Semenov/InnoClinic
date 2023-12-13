using Domain.Models.Enums;

namespace Application.DTOs.Specializations
{
    public sealed class ChangeSpecializationStatusDto
    {
        public int Id { get; set; }
        public SpecializationStatuses Status { get; set; }
    }
}
