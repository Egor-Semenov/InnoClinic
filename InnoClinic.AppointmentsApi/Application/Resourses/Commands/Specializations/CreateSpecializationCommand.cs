using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Specializations
{
    public sealed class CreateSpecializationCommand : IRequest<Specialization>
    {
        public string SpecializationName { get; set; }
    }
}
