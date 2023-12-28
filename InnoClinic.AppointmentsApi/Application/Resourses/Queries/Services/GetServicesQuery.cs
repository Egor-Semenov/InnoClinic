using Application.DTOs.Services;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Services
{
    public sealed class GetServicesQuery : IRequest<List<ServiceDto>>
    {
        public ServiceParameters ServiceParameters { get; set; }
    }
}
