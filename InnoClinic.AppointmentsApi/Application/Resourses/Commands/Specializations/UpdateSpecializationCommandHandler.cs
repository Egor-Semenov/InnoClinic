using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Specializations
{
    public sealed class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand, Specialization>
    {
        private readonly IBaseRepository<Specialization> _specializationsRepository;

        public UpdateSpecializationCommandHandler(IBaseRepository<Specialization> specializationsRepository)
        {
            _specializationsRepository = specializationsRepository;
        }

        public async Task<Specialization> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = await _specializationsRepository.FindByCondition(x => x.SpecializationId == request.Id, false).FirstOrDefaultAsync();
            if (specialization is null)
            {
                throw new NotFoundException($"Specialization with id: {request.Id} is not found.");
            }

            specialization.SpecializationName = specialization.SpecializationName;

            await _specializationsRepository.Update(specialization);
            return specialization;
        }
    }
}
