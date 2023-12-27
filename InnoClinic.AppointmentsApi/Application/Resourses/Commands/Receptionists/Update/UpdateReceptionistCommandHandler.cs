using Application.DTOs.Receptionists;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Resourses.Commands.Receptionists.Update
{
    public sealed class UpdateReceptionistCommandHandler : IRequestHandler<UpdateReceptionistCommand, UpdateReceptionistDto>
    {
        private readonly IBaseRepository<Receptionist> _receptionistsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateReceptionistCommand> _validator;

        public UpdateReceptionistCommandHandler(IBaseRepository<Receptionist> receptionistsRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<UpdateReceptionistCommand> validator)
        {
            _receptionistsRepository = receptionistsRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateReceptionistDto> Handle(UpdateReceptionistCommand request, CancellationToken cancellationToken)
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

            var receptionist = await _receptionistsRepository.FindByCondition(x => x.Email == request.Email, false).FirstOrDefaultAsync();
            if (receptionist is null)
            {
                throw new NotFoundException($"Receptionist with email: {request.Email} is not found.");
            }

            receptionist.FirstName = request.FirstName;
            receptionist.LastName = request.LastName;
            receptionist.MiddleName = request.MiddleName;
            receptionist.OfficeId = request.OfficeId;

            _receptionistsRepository.Update(receptionist);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UpdateReceptionistDto>(receptionist);
        }
    }
}
