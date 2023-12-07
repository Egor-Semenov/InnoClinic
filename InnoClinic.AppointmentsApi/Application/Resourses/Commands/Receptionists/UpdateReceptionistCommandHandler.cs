using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Receptionists
{
    public sealed class UpdateReceptionistCommandHandler : IRequestHandler<UpdateReceptionistCommand, Receptionist>
    {
        private readonly IBaseRepository<Receptionist> _receptionistsRepository;

        public UpdateReceptionistCommandHandler(IBaseRepository<Receptionist> receptionistsRepository)
        {
            _receptionistsRepository = receptionistsRepository;
        }

        public async Task<Receptionist> Handle(UpdateReceptionistCommand request, CancellationToken cancellationToken)
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
            return receptionist;
        }
    }
}
