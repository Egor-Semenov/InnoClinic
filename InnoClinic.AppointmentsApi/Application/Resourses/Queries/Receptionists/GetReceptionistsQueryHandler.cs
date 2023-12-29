using Application.DTOs.Receptionists;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Receptionists
{
    public sealed class GetReceptionistsQueryHandler : IRequestHandler<GetReceptionistsQuery, PagedList<ReceptionistDto>>
    {
        private readonly IReceptionistRepository _receptionistRepository;
        private readonly IMapper _mapper;

        public GetReceptionistsQueryHandler(IReceptionistRepository receptionistRepository, IMapper mapper)
        {
            _receptionistRepository = receptionistRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<ReceptionistDto>> Handle(GetReceptionistsQuery request, CancellationToken cancellationToken)
        {
            var receptionists = await _receptionistRepository.GetReceptionistsAsync(request.ReceptionistParameters, false);

            var receptionistsDto = _mapper.Map<List<ReceptionistDto>>(receptionists);
            return new PagedList<ReceptionistDto>(receptionistsDto, receptionists.MetaData.TotalCount, receptionists.MetaData.CurrentPage, receptionists.MetaData.PageSize);
        }
    }
}
