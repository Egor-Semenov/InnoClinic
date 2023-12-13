using Application.DTOs.Receptionists;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Receptionists.Delete
{
    public sealed class DeleteReceptionistCommandHandler : IRequestHandler<DeleteReceptionistCommand, DeleteReceptionistDto>
    {
        private readonly IBaseRepository<Receptionist> _receptionistsRepository;
        private readonly IMapper _mapper;

        public DeleteReceptionistCommandHandler(IBaseRepository<Receptionist> receptionistsRepository, IMapper mapper)
        {
            _receptionistsRepository = receptionistsRepository;
            _mapper = mapper;
        }

        public async Task<DeleteReceptionistDto> Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
        {
            var receptionist = await _receptionistsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();

            if (receptionist is null)
            {
                throw new NotFoundException($"Receptionist with id: {request.Id} is not found.");
            }

            await _receptionistsRepository.Delete(receptionist);
            return _mapper.Map<DeleteReceptionistDto>(receptionist);
        }
    }
}
