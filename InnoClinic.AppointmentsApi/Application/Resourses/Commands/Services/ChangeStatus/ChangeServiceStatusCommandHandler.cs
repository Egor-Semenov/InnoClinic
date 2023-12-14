using Application.DTOs.Services;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Services.ChangeStatus
{
    public sealed class ChangeServiceStatusCommandHandler : IRequestHandler<ChangeServiceStatusCommand, ChangeServiceStatusDto>
    {
        private readonly IBaseRepository<Service> _servicesRepository;
        private readonly IMapper _mapper;

        public ChangeServiceStatusCommandHandler(IBaseRepository<Service> servicesRepository, IMapper mapper)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
        }

        public async Task<ChangeServiceStatusDto> Handle(ChangeServiceStatusCommand request, CancellationToken cancellationToken)
        {
            var service = await _servicesRepository.FindByCondition(x => x.ServiceId == request.Id, false).FirstOrDefaultAsync();
            if (service is null)
            {
                throw new NotFoundException($"Service with id: {request.Id} is not found.");
            }

            if (service.StatusId == (int)request.Status)
            {
                throw new BadRequestException($"Service with id: {request.Id} has {request.Status} status already.");
            }

            service.StatusId = (int)request.Status;

            await _servicesRepository.Update(service);
            return _mapper.Map<ChangeServiceStatusDto>(service);
        }
    }
}
