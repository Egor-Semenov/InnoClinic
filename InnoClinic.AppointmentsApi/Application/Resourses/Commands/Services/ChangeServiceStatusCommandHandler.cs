using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Commands.Services
{
    public sealed class ChangeServiceStatusCommandHandler : IRequestHandler<ChangeServiceStatusCommand, Service>
    {
        private readonly IBaseRepository<Service> _servicesRepository;

        public ChangeServiceStatusCommandHandler(IBaseRepository<Service> servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public async Task<Service> Handle(ChangeServiceStatusCommand request, CancellationToken cancellationToken)
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

            return service;
        }
    }
}
