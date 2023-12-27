﻿using Application.DTOs.Specializations;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Specializations.Update
{
    public sealed class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand, UpdateSpecializationDto>
    {
        private readonly IBaseRepository<Specialization> _specializationsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateSpecializationCommand> _validator;

        public UpdateSpecializationCommandHandler(IBaseRepository<Specialization> specializationsRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<UpdateSpecializationCommand> validator)
        {
            _specializationsRepository = specializationsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<UpdateSpecializationDto> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
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

            var specialization = await _specializationsRepository.FindByCondition(x => x.SpecializationId == request.Id, false).FirstOrDefaultAsync();
            if (specialization is null)
            {
                throw new NotFoundException($"Specialization with id: {request.Id} is not found.");
            }

            specialization.SpecializationName = specialization.SpecializationName;

            _specializationsRepository.Update(specialization);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UpdateSpecializationDto>(specialization);
        }
    }
}
