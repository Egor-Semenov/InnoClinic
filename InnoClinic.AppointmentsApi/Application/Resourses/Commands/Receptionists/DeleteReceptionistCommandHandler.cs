using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Receptionists
{
    public sealed class DeleteReceptionistCommandHandler : IRequestHandler<DeleteReceptionistCommand, Receptionist>
    {
        private readonly IBaseRepository<Receptionist> _receptionistsRepository;

        public DeleteReceptionistCommandHandler(IBaseRepository<Receptionist> receptionistsRepository)
        {
            _receptionistsRepository = receptionistsRepository;
        }

        public async Task<Receptionist> Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
        {
            var receptionist = await _receptionistsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();

            if (receptionist is null)
            {
                throw new NotFoundException($"Receptionist with id: {request.Id} is not found.");
            }

            await _receptionistsRepository.Delete(receptionist);
            return receptionist;
        }
    }
}
