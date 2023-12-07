using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Specializations
{
    public sealed class ChangeSpecializationStatusCommand : IRequest<Specialization>
    {
        public int Id { get; set; }
        public SpecializationStatuses Status { get; set; }
    }
}
