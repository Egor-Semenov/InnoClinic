using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Specializations
{
    public sealed class ChangeSpecializationStatusCommandHandler : IRequestHandler<ChangeSpecializationStatusCommand, Specialization>
    {
        private readonly IBaseRepository<Specialization> _specializationsRepository;

        public ChangeSpecializationStatusCommandHandler(IBaseRepository<Specialization> specializationsRepository)
        {
            _specializationsRepository = specializationsRepository;
        }

        public async Task<Specialization> Handle(ChangeSpecializationStatusCommand request, CancellationToken cancellationToken)
        {
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

            await _specializationsRepository.Update(specialization);
            return specialization;
        }
    }
}
