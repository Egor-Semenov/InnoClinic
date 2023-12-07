using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
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
    public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, Service>
    {
        private readonly IBaseRepository<Service> _servicesRepository;

        public UpdateServiceCommandHandler(IBaseRepository<Service> servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public async Task<Service> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _servicesRepository.FindByCondition(x => x.ServiceId == request.Id, false).FirstOrDefaultAsync();
            if (service is null)
            {
                throw new NotFoundException($"Service with id: {request.Id} is not found.");
            }

            service.ServiceName = request.ServiceName;
            service.Price = request.Price;
            await _servicesRepository.Update(service);

            return service;
        }
    }
}
