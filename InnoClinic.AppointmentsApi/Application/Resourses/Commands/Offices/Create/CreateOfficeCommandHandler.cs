using Application.DTOs.Offices;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using FluentValidation;
using MediatR;
using System.Text;

namespace Application.Resourses.Commands.Offices.Create
{
    public sealed class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, OfficeDto>
    {
        private readonly IBaseRepository<Office> _officesRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOfficeCommand> _validator; 

        public CreateOfficeCommandHandler(IBaseRepository<Office> officesRepository, IMapper mapper, IValidator<CreateOfficeCommand> validator)
        {
            _officesRepository = officesRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<OfficeDto> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
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
