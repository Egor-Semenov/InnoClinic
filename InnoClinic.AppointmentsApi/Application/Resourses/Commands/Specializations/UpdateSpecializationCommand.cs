using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Specializations
{
    public sealed class UpdateSpecializationCommand : IRequest<Specialization>
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; }
    }
}
