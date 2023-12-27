using Application.DTOs.Specializations;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Specializations.Create
{
    public sealed class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, SpecializationDto>
    {
        private readonly IBaseRepository<Specialization> _specializationsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateSpecializationCommand> _validator;

        public CreateSpecializationCommandHandler(IBaseRepository<Specialization> specializationsRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<CreateSpecializationCommand> validator)
        {
            _specializationsRepository = specializationsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<SpecializationDto> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
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

            if (await CheckSpecializationAlreadyExists(request.SpecializationName))
            {
                throw new BadRequestException($"{request.SpecializationName} specialization exists in the system already.");
            }

            var specialization = new Specialization
            {
                SpecializationName = request.SpecializationName,
                StatusId = (int)SpecializationStatuses.Active
            };

            _specializationsRepository.Create(specialization);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SpecializationDto>(specialization);
        }

        private async Task<bool> CheckSpecializationAlreadyExists(string specializationName)
        {
            var specialization = await _specializationsRepository.FindByCondition(x => x.SpecializationName == specializationName, false).FirstOrDefaultAsync();
            if (specialization is not null)
            {
                return true;
            }

            return false;
        }
    }
}
