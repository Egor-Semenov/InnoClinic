using Application.DTOs.Specializations;
using MediatR;

namespace Application.Resourses.Commands.Specializations.Create
{
    public sealed class CreateSpecializationCommand : IRequest<SpecializationDto>
    {
        public string SpecializationName { get; set; }
    }
}
