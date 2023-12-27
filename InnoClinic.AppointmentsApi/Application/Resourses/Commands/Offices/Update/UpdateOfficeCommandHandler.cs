using Application.DTOs.Offices;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Offices.Update
{
    public sealed class UpdateOfficeCommandHandler : IRequestHandler<UpdateOfficeCommand, UpdateOfficeDto>
    {
        private readonly IBaseRepository<Office> _officesRepository;
        private readonly IMapper _mapper;

        public UpdateOfficeCommandHandler(IBaseRepository<Office> officesRepository, IMapper mapper)
        {
            _officesRepository = officesRepository;
            _mapper = mapper;
        }

        public async Task<UpdateOfficeDto> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = await _officesRepository.FindByCondition(x => x.OfficeId == request.OfficeId, false).FirstOrDefaultAsync();

            if (office is null)
            {
                throw new NotFoundException($"Office with id: {request.OfficeId} is not found");
            }

            office.City = request.City;
            office.Street = request.Street;
            office.HouseNumber = request.HouseNumber;
            office.OfficeNumber = request.OfficeNumber;
            office.PhoneNumber = request.PhoneNumber;
            office.PhotoFilePath = request.PhotoFilePath;

            await _officesRepository.Update(office);
            return _mapper.Map<UpdateOfficeDto>(office);
        }
    }
}
