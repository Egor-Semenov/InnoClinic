using Domain.Models.Enums;

namespace Application.DTOs.Offices
{
    public sealed class UpdateOfficeDto
    {
        public int OfficeId { get; set; }
        public string OfficeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public OfficeStatuses Status { get; set; }
        public string PhotoFilePath { get; set; }
    }
}
