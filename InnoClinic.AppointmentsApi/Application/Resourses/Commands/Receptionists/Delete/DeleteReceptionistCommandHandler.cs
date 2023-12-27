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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReceptionistCommandHandler(IBaseRepository<Receptionist> receptionistsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _receptionistsRepository = receptionistsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteReceptionistDto> Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
        {
            var receptionist = await _receptionistsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();

            if (receptionist is null)
            {
                throw new NotFoundException($"Receptionist with id: {request.Id} is not found.");
            }

            _receptionistsRepository.Delete(receptionist);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DeleteReceptionistDto>(receptionist);
        }
    }
}
