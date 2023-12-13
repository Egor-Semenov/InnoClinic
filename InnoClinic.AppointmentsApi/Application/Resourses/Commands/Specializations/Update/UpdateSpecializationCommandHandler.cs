using Application.DTOs.Specializations;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Specializations.Update
{
    public sealed class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand, UpdateSpecializationDto>
    {
        private readonly IBaseRepository<Specialization> _specializationsRepository;
        private readonly IMapper _mapper;

        public UpdateSpecializationCommandHandler(IBaseRepository<Specialization> specializationsRepository, IMapper mapper)
        {
            _specializationsRepository = specializationsRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSpecializationDto> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = await _specializationsRepository.FindByCondition(x => x.SpecializationId == request.Id, false).FirstOrDefaultAsync();
            if (specialization is null)
            {
                throw new NotFoundException($"Specialization with id: {request.Id} is not found.");
            }

            specialization.SpecializationName = specialization.SpecializationName;

            await _specializationsRepository.Update(specialization);
            return _mapper.Map<UpdateSpecializationDto>(specialization);
        }
    }
}
