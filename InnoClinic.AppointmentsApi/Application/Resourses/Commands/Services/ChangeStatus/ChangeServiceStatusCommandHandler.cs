using Application.DTOs.Services;
using AutoMapper;
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

namespace Application.Resourses.Commands.Services.ChangeStatus
{
    public sealed class ChangeServiceStatusCommandHandler : IRequestHandler<ChangeServiceStatusCommand, ChangeServiceStatusDto>
    {
        private readonly IBaseRepository<Service> _servicesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeServiceStatusCommandHandler(IBaseRepository<Service> servicesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

            _servicesRepository.Update(service);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ChangeServiceStatusDto>(service);
        }
    }
}
