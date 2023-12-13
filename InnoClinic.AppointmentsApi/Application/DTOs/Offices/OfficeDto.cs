using Domain.Models.Enums;

namespace Application.DTOs.Offices
{
    public sealed class OfficeDto
    {
        public string OfficeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public OfficeStatuses Status { get; set; }
        public string PhotoFilePath { get; set; }
    }
}
