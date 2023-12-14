using Application.DTOs.Specializations;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Specializations.ChangeStatus
{
    public sealed class ChangeSpecializationStatusCommandHandler : IRequestHandler<ChangeSpecializationStatusCommand, ChangeSpecializationStatusDto>
    {
        private readonly IBaseRepository<Specialization> _specializationsRepository;
        private readonly IMapper _mapper;

        public ChangeSpecializationStatusCommandHandler(IBaseRepository<Specialization> specializationsRepository, IMapper mapper)
        {
            _specializationsRepository = specializationsRepository;
            _mapper = mapper;
        }

        public async Task<ChangeSpecializationStatusDto> Handle(ChangeSpecializationStatusCommand request, CancellationToken cancellationToken)
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
            return _mapper.Map<ChangeSpecializationStatusDto>(specialization);
        }
    }
}
