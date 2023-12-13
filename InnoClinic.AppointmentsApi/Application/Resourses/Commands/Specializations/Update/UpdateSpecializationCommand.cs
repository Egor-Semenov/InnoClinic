using Application.DTOs.Specializations;
using MediatR;

namespace Application.Resourses.Commands.Specializations.Update
{
    public sealed class UpdateSpecializationCommand : IRequest<UpdateSpecializationDto>
    {
        public int Id { get; set; }
        public string SpecializationName { get; set; }
    }
}
