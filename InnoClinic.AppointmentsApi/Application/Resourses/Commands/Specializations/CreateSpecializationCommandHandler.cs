using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Specializations
{
    public sealed class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, Specialization>
    {
        private readonly IBaseRepository<Specialization> _specializationsRepository;

        public CreateSpecializationCommandHandler(IBaseRepository<Specialization> specializationsRepository)
        {
            _specializationsRepository = specializationsRepository;
        }

        public async Task<Specialization> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            if (await CheckSpecializationAlreadyExists(request.SpecializationName))
            {
                throw new BadRequestException($"{request.SpecializationName} specialization exists in the system already.");
            }

            var specialization = new Specialization
            {
                SpecializationName = request.SpecializationName,
                StatusId = (int)SpecializationStatuses.Active
            };

            await _specializationsRepository.Create(specialization);
            return specialization;
        }

        private async Task<bool> CheckSpecializationAlreadyExists(string specializationName)
        {
            var specialization = await _specializationsRepository.FindByCondition(x => x.SpecializationName == specializationName, false).FirstOrDefaultAsync();
            if (specialization is not null)
            {
                return true;
            }

            return false;
        }
    }
}
