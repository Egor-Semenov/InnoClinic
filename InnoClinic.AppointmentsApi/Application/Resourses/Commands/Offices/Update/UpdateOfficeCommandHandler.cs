using Application.DTOs.Offices;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Offices.Update
{
    public sealed class UpdateOfficeCommandHandler : IRequestHandler<UpdateOfficeCommand, UpdateOfficeDto>
    {
        private readonly IBaseRepository<Office> _officesRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateOfficeCommand> _validator;

        public UpdateOfficeCommandHandler(IBaseRepository<Office> officesRepository, IMapper mapper, IValidator<UpdateOfficeCommand> validator)
        {
            _officesRepository = officesRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UpdateOfficeDto> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
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
