using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Queries.Doctors
{
    public sealed class GetDoctorByIdQuery : IRequest<Doctor>
    {
        public int Id { get; set; }
    }
}
