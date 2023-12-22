using Application.DTOs.Services;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Services.ChangeStatus
{
    public sealed class ChangeServiceStatusCommandHandler : IRequestHandler<ChangeServiceStatusCommand, ChangeServiceStatusDto>
    {
        private readonly IBaseRepository<Service> _servicesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ChangeServiceStatusCommand> _validator;

        public ChangeServiceStatusCommandHandler(IBaseRepository<Service> servicesRepository, IMapper mapper, IValidator<ChangeServiceStatusCommand> validator, IUnitOfWork unitOfWork)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ChangeServiceStatusDto> Handle(ChangeServiceStatusCommand request, CancellationToken cancellationToken)
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
