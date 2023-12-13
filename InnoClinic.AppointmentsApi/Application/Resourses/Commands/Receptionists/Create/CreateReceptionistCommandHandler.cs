using Application.DTOs.Receptionists;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Receptionists.Create
{
    public sealed class CreateReceptionistCommandHandler : IRequestHandler<CreateReceptionistCommand, ReceptionistDto>
    {
        private readonly IBaseRepository<Receptionist> _receptionistRepository;
        private readonly IMapper _mapper;

        public CreateReceptionistCommandHandler(IBaseRepository<Receptionist> receptionistRepository, IMapper mapper)
        {
            _receptionistRepository = receptionistRepository;
            _mapper = mapper;
        }

        public async Task<ReceptionistDto> Handle(CreateReceptionistCommand request, CancellationToken cancellationToken)
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
            return _mapper.Map<ReceptionistDto>(receptionist);
        }
    }
}
