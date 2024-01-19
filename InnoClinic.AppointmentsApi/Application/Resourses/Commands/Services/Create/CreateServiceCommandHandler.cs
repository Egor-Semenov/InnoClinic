using Application.DTOs.Services;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Services.Create
{
    public sealed class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ServiceDto>
    {
        private readonly IBaseRepository<Service> _serviceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateServiceCommand> _validator;

        public CreateServiceCommandHandler(IBaseRepository<Service> serviceRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<CreateServiceCommand> validator)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var stringBuilder = new StringBuilder();
                foreach (var error in validationResult.Errors)
                {
                    stringBuilder.AppendLine(error.ErrorMessage);
                }

                throw new BadRequestException(stringBuilder.ToString());
            }

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

            _serviceRepository.Create(service);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ServiceDto>(service);
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
