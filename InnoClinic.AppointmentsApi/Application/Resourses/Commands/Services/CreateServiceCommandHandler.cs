using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Commands.Services
{
    public sealed class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, Service>
    {
        private readonly IBaseRepository<Service> _serviceRepository;

        public CreateServiceCommandHandler(IBaseRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Service> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            if (await CheckServiceAlreadyExists(request.ServiceName))
            {
                throw new BadRequestException($"{request.ServiceName} service exists in the system already.");
            }

            var service = new Service
            {
                ServiceName = request.ServiceName,
                ServiceCategoryId = (int)request.Category,
                Price = request.Price,
                StatusId = (int)ServiceStatuses.Active
            };

            await _serviceRepository.Create(service);
            return service;
        }

        private async Task<bool> CheckServiceAlreadyExists(string serviceName)
        {
            var service = await _serviceRepository.FindByCondition(x => x.ServiceName == serviceName, false).FirstOrDefaultAsync();
            if (service is not null)
            {
                return true;
            }

            return false;
        }
    }
}
