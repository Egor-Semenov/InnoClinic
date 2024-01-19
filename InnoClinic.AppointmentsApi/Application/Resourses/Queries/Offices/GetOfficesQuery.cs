using Application.DTOs.Offices;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Offices
{
    public sealed class GetOfficesQuery : IRequest<List<OfficeDto>>
    {
        public OfficeParameters OfficeParameters { get; set; }
    }
}
