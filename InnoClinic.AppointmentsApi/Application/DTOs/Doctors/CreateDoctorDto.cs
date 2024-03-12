using Domain.Models.Enums;

namespace Application.DTOs.Doctors
{
    public sealed class CreateDoctorDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public int SpecializationId { get; set; }
        public int OfficeId { get; set; }
        public DateTime CareerStartDate { get; set; }
        public string? PhotoFilePath { get; set; }
    }
}
