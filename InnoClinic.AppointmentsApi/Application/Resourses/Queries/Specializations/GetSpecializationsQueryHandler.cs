using Application.DTOs.Specializations;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Resourses.Queries.Specializations
{
    public sealed class GetSpecializationsQueryHandler : IRequestHandler<GetSpecializationsQuery, List<SpecializationDto>>
    {
        private readonly ISpecializationRepository _specializationsRepository;
        private readonly IMapper _mapper;

        public GetSpecializationsQueryHandler(ISpecializationRepository specializationsRepository, IMapper mapper)
        {
            _specializationsRepository = specializationsRepository;
            _mapper = mapper;
        }

        public async Task<List<SpecializationDto>> Handle(GetSpecializationsQuery request, CancellationToken cancellationToken)
        {
            var specializations = await _specializationsRepository.GetSpecializationsAsync(request.SpecializationParameters, false);
            return _mapper.Map<List<SpecializationDto>>(specializations);
        }
    }
}
