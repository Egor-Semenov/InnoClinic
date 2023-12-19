using Application.DTOs.Offices;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Commands.Offices.Create
{
    public sealed class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, OfficeDto>
    {
        private readonly IBaseRepository<Office> _officesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOfficeCommandHandler(IBaseRepository<Office> officesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _officesRepository = officesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<OfficeDto> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = new Office
            {
                City = request.City,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                OfficeNumber = request.OfficeNumber,
                PhoneNumber = request.PhoneNumber,
                StatusId = (int)OfficeStatuses.Active,
                PhotoFilePath = request.PhotoFilePath
            };

            _officesRepository.Create(office);         
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<OfficeDto>(office);
        }
    }
}
