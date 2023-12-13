using Application.DTOs.Services;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Services.Update
{
    public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, UpdateServiceDto>
    {
        private readonly IBaseRepository<Service> _servicesRepository;
        private readonly IMapper _mapper;

        public UpdateServiceCommandHandler(IBaseRepository<Service> servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }

        public async Task<UpdateServiceDto> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _servicesRepository.FindByCondition(x => x.ServiceId == request.Id, false).FirstOrDefaultAsync();
            if (service is null)
            {
                throw new NotFoundException($"Service with id: {request.Id} is not found.");
            }

            service.ServiceName = request.ServiceName;
            service.Price = request.Price;
            service.ServiceCategoryId = (int)request.Category;

            await _servicesRepository.Update(service);
            return _mapper.Map<UpdateServiceDto>(service);
        }
    }
}
