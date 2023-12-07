using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Patients
{
    public sealed class UpdatePatientCommand : IRequest<Patient>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoFilePath { get; set; }
    }
}
