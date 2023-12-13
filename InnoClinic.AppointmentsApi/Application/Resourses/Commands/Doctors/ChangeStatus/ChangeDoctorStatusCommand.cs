using Application.DTOs.Doctors;
using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Doctors.ChangeStatus
{
    public sealed class ChangeDoctorStatusCommand : IRequest<ChangeDoctorStatusDto>
    {
        public int Id { get; set; }
        public DoctorsStatuses Status { get; set; }
    }
}
