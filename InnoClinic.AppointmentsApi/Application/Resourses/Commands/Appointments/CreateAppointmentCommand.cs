using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Appointments
{
    public sealed class CreateAppointmentCommand : IRequest<Appointment>
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public SpecializationTypes SpecializationType { get; set; }
        public ServiceTypes ServiceType { get; set; }
        public int OfficeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
    }
}
