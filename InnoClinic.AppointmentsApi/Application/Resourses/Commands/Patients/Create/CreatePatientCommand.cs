using Application.DTOs.Patients;
using MediatR;

namespace Application.Resourses.Commands.Patients.Create
{
    public sealed class CreatePatientCommand : IRequest<PatientDto>
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhotoFilePath { get; set; }
    }
}
