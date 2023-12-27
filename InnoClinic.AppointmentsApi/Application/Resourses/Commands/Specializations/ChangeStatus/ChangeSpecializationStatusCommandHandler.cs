using Application.DTOs.Specializations;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Specializations.ChangeStatus
{
    public sealed class ChangeSpecializationStatusCommandHandler : IRequestHandler<ChangeSpecializationStatusCommand, ChangeSpecializationStatusDto>
    {
        private readonly IBaseRepository<Specialization> _specializationsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ChangeSpecializationStatusCommand> _validator;

        public ChangeSpecializationStatusCommandHandler(IBaseRepository<Specialization> specializationsRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<ChangeSpecializationStatusCommand> validator)
        {
            _specializationsRepository = specializationsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ChangeSpecializationStatusDto> Handle(ChangeSpecializationStatusCommand request, CancellationToken cancellationToken)
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

            if (specialization.StatusId == (int)request.Status)
            {
                throw new BadRequestException($"Specialization with id: {request.Id} has {request.Status} already.");
            }

            specialization.StatusId = (int)request.Status;

            _specializationsRepository.Update(specialization);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ChangeSpecializationStatusDto>(specialization);
        }
    }
}
