using Application.DTOs.Receptionists;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Receptionists
{
    public sealed class GetReceptionistsQuery : IRequest<PagedList<ReceptionistDto>>
    {
        public ReceptionistParameters ReceptionistParameters { get; set; }
    }
}
