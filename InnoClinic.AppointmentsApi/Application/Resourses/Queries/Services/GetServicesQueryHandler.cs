using Application.DTOs.Services;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Resourses.Queries.Services
{
    public sealed class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, List<ServiceDto>>
    {
        private readonly IServiceRepository _servicesRepository;
        private readonly IMapper _mapper;

        public GetServicesQueryHandler(IServiceRepository servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }

        public async Task<List<ServiceDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _servicesRepository.GetServicesAsync(request.ServiceParameters, false);
            return _mapper.Map<List<ServiceDto>>(services);
        }
    }
}
