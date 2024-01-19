using Application.DTOs.Offices;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Offices.ChangeStatus
{
    public sealed class ChangeOfficeStatusCommand : IRequest<ChangeOfficeStatusDto>
    {
        public int OfficeId { get; set; }
        public OfficeStatuses Status { get; set; }
    }
}
