using Domain.Models.Enums;

namespace Application.DTOs.Doctors
{
    public sealed class UpdateDoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int SpecializationId { get; set; }
        public int OfficeId { get; set; }
        public string Expirience { get; set; }
        public DoctorsStatuses Status { get; set; }
        public string PhotoFilePath { get; set; }
    }
}
