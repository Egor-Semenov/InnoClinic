using Application.DTOs.Specializations;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Specializations
{
    public sealed class GetSpecializationsQuery : IRequest<List<SpecializationDto>>
    {
        public SpecializationParameters SpecializationParameters { get; set; }
    }
}
