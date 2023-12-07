using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Doctors
{
    public sealed class ChangeDoctorStatusCommand : IRequest<Doctor>
    {
        public int Id { get; set; }
        public DoctorsStatuses Status { get; set; }
    }
}
