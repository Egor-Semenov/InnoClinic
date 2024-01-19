using Application.DTOs.Offices;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Resourses.Queries.Offices
{
    public sealed class GetOfficesQueryHandler : IRequestHandler<GetOfficesQuery, List<OfficeDto>>
    {
        private readonly IOfficeRepository _officesRepository;
        private readonly IMapper _mapper;

        public GetOfficesQueryHandler(IOfficeRepository officesRepository, IMapper mapper)
        {
            _officesRepository = officesRepository;
            _mapper = mapper;
        }

        public async Task<List<OfficeDto>> Handle(GetOfficesQuery request, CancellationToken cancellationToken)
        {
            var offices = await _officesRepository.GetOfficesAsync(request.OfficeParameters, false);
            return _mapper.Map<List<OfficeDto>>(offices);
        }
    }
}
