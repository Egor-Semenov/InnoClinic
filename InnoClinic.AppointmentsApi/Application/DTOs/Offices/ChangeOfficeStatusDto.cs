using Domain.Models.Enums;

namespace Application.DTOs.Offices
{
    public sealed class ChangeOfficeStatusDto
    {
        public int OfficeId { get; set; }
        public OfficeStatuses Status { get; set; }
    }
}
