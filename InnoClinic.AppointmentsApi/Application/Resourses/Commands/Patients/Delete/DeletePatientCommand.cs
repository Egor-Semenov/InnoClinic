using Application.DTOs.Patients;
using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Patients.Delete
{
    public sealed class DeletePatientCommand : IRequest<DeletePatientDto>
    {
        public int Id { get; set; }
    }
}
