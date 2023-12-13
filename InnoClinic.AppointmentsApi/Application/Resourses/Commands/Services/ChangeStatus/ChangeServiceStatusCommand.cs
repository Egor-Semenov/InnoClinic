using Application.DTOs.Services;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Services.ChangeStatus
{
    public sealed class ChangeServiceStatusCommand : IRequest<ChangeServiceStatusDto>
    {
        public int Id { get; set; }
        public ServiceStatuses Status { get; set; }
    }
}
