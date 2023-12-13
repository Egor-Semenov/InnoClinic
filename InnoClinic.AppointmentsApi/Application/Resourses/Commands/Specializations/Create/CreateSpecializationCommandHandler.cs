using Application.DTOs.Specializations;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Specializations.Create
{
    public sealed class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, SpecializationDto>
    {
        private readonly IBaseRepository<Specialization> _specializationsRepository;
        private readonly IMapper _mapper;

        public CreateSpecializationCommandHandler(IBaseRepository<Specialization> specializationsRepository, IMapper mapper)
        {
            _specializationsRepository = specializationsRepository;
            _mapper = mapper;
        }

        public async Task<SpecializationDto> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
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
            return _mapper.Map<SpecializationDto>(specialization);
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
