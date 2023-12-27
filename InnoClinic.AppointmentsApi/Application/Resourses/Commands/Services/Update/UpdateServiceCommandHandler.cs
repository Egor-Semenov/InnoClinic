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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateServiceCommandHandler(IBaseRepository<Service> servicesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _servicesRepository = servicesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

            _servicesRepository.Update(service);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UpdateServiceDto>(service);
        }
    }
}
