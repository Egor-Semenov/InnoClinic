using Application.DTOs.Doctors;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Doctors
{
    public sealed class GetDoctorsQuery : IRequest<PagedList<DoctorDto>>
    {
        public DoctorParameters DoctorParameters { get; set; }
    }
}
