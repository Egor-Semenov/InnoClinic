using Application.DTOs.Doctors;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Doctors.Update
{
    public sealed class UpdateDoctorCommand : IRequest<UpdateDoctorDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int SpecializationId { get; set; }
        public int OfficeId { get; set; }
        public DateTime CareerStartYear { get; set; }
        public DoctorsStatuses Status { get; set; }
        public string PhotoFilePath { get; set; }
    }
}
