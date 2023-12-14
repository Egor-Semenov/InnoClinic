using Application.DTOs.Offices;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Offices.Create
{
    public sealed class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, OfficeDto>
    {
        private readonly IBaseRepository<Office> _officesRepository;
        private readonly IMapper _mapper;

        public CreateOfficeCommandHandler(IBaseRepository<Office> officesRepository, IMapper mapper)
        {
            _officesRepository = officesRepository;
            _mapper = mapper;
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

            await _officesRepository.Create(office);         
            return _mapper.Map<OfficeDto>(office);
        }
    }
}
