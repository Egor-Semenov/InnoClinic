using Application.DTOs.Receptionists;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using FluentValidation;
using MediatR;
using System.Text;

namespace Application.Resourses.Commands.Receptionists.Create
{
    public sealed class CreateReceptionistCommandHandler : IRequestHandler<CreateReceptionistCommand, ReceptionistDto>
    {
        private readonly IBaseRepository<Receptionist> _receptionistRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateReceptionistCommand> _validator;

        public CreateReceptionistCommandHandler(IBaseRepository<Receptionist> receptionistRepository, IMapper mapper, IValidator<CreateReceptionistCommand> validator, IUnitOfWork unitOfWork)
        {
            _receptionistRepository = receptionistRepository;
            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReceptionistDto> Handle(CreateReceptionistCommand request, CancellationToken cancellationToken)
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

            var receptionist = new Receptionist
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                OfficeId = request.OfficeId
            };

            _receptionistRepository.Create(receptionist);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ReceptionistDto>(receptionist);
        }
    }
}
