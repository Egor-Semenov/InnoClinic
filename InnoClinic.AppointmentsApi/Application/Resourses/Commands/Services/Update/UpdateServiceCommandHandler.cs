using Application.DTOs.Services;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Services.Update
{
    public sealed class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, UpdateServiceDto>
    {
        private readonly IBaseRepository<Service> _servicesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateServiceCommand> _validator;

        public UpdateServiceCommandHandler(IBaseRepository<Service> servicesRepository, IMapper mapper, IValidator<UpdateServiceCommand> validator, IUnitOfWork unitOfWork)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateServiceDto> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
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

            var service = await _servicesRepository.FindByCondition(x => x.ServiceId == request.Id, false).FirstOrDefaultAsync();
            if (service is null)
            {
                throw new NotFoundException($"Service with id: {request.Id} is not found.");
            }

            service.ServiceName = request.ServiceName;
            service.Price = request.Price;
            service.ServiceCategoryId = (int)request.Category;

            _servicesRepository.Update(service);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UpdateServiceDto>(service);
        }
    }
}
