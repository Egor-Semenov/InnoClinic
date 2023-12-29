using Application.DTOs.Patients;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Patients
{
    public sealed class GetPatientsQuery : IRequest<PagedList<PatientDto>>
    {
        public PatientParameters PatientParameters { get; set; }
    }
}
