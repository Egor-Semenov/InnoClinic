using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Patients
{
    public sealed class DeletePatientCommand : IRequest<Patient>
    {
        public int Id { get; set; }
    }
}
