using Application.DTOs.Appointments;
using Domain.Models.Enums;

namespace Application.DTOs.Doctors
{
    public sealed class DoctorDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public int OfficeId { get; set; }
        public string Expirience { get; set; }
        public DoctorsStatuses Status { get; set; }
        public string PhotoFilePath { get; set; }
        public List<AppointmentDto> Appointments { get; set; }
    }
}
