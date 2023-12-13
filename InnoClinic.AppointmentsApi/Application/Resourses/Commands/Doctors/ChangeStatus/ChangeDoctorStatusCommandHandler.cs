using Application.DTOs.Doctors;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Doctors.ChangeStatus
{
    public sealed class ChangeDoctorStatusCommandHandler : IRequestHandler<ChangeDoctorStatusCommand, ChangeDoctorStatusDto>
    {
        private readonly IBaseRepository<Doctor> _doctorsRepository;
        private readonly IMapper _mapper;

        public ChangeDoctorStatusCommandHandler(IBaseRepository<Doctor> doctorsRepository, IMapper mapper)
        {
            _doctorsRepository = doctorsRepository;
            _mapper = mapper;
        }

        public async Task<ChangeDoctorStatusDto> Handle(ChangeDoctorStatusCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();

            if (doctor is null)
            {
                throw new NotFoundException($"Doctor with id: {request.Id} is not found.");
            }

            if (doctor.StatusId == (int)request.Status)
            {
                throw new BadRequestException($"Doctor with id: {request.Id} has {request.Status} status already.");
            }

            doctor.StatusId = (int)request.Status;

            await _doctorsRepository.Update(doctor);
            return _mapper.Map<ChangeDoctorStatusDto>(doctor);
        }
    }
}
