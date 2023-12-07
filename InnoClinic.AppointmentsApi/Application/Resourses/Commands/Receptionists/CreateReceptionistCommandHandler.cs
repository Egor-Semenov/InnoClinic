using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Receptionists
{
    public sealed class CreateReceptionistCommandHandler : IRequestHandler<CreateReceptionistCommand, Receptionist>
    {
        private readonly IBaseRepository<Receptionist> _receptionistRepository;

        public CreateReceptionistCommandHandler(IBaseRepository<Receptionist> receptionistRepository)
        {
            _receptionistRepository = receptionistRepository;
        }

        public async Task<Receptionist> Handle(CreateReceptionistCommand request, CancellationToken cancellationToken)
        {
            var receptionist = new Receptionist
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Email = request.Email,
                OfficeId = request.OfficeId
            };

            await _receptionistRepository.Create(receptionist);
            return receptionist;
        }
    }
}
