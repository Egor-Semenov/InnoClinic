using Application.DTOs.Doctors;
using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Queries.Doctors
{
    public sealed class GetDoctorByIdQuery : IRequest<DoctorDto>
    {
        public int Id { get; set; }
    }
}
