using Application.DTOs.Offices;
using MediatR;

namespace Application.Resourses.Commands.Offices.Update
{
    public sealed class UpdateOfficeCommand : IRequest<UpdateOfficeDto>
    {
        public int OfficeId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string? HouseNumber { get; set; }
        public string OfficeNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string? PhotoFilePath { get; set; }
    }
}
