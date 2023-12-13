using Application.DTOs.Receptionists;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Receptionists.Update
{
    public sealed class UpdateReceptionistCommandHandler : IRequestHandler<UpdateReceptionistCommand, UpdateReceptionistDto>
    {
        private readonly IBaseRepository<Receptionist> _receptionistsRepository;
        private readonly IMapper _mapper;

        public UpdateReceptionistCommandHandler(IBaseRepository<Receptionist> receptionistsRepository, IMapper mapper)
        {
            _receptionistsRepository = receptionistsRepository;
            _mapper = mapper;
        }

        public async Task<UpdateReceptionistDto> Handle(UpdateReceptionistCommand request, CancellationToken cancellationToken)
        {
            var receptionist = await _receptionistsRepository.FindByCondition(x => x.Email == request.Email, false).FirstOrDefaultAsync();
            if (receptionist is null)
            {
                throw new NotFoundException($"Receptionist with email: {request.Email} is not found.");
            }

            receptionist.FirstName = request.FirstName;
            receptionist.LastName = request.LastName;
            receptionist.MiddleName = request.MiddleName;
            receptionist.OfficeId = request.OfficeId;

            await _receptionistsRepository.Update(receptionist);
            return _mapper.Map<UpdateReceptionistDto>(receptionist);
        }
    }
}
