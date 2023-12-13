using Application.DTOs.Specializations;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Specializations.ChangeStatus
{
    public sealed class ChangeSpecializationStatusCommand : IRequest<ChangeSpecializationStatusDto>
    {
        public int Id { get; set; }
        public SpecializationStatuses Status { get; set; }
    }
}
