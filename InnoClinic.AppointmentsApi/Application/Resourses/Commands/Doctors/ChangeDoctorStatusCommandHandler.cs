using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Doctors
{
    public sealed class ChangeDoctorStatusCommandHandler : IRequestHandler<ChangeDoctorStatusCommand, Doctor>
    {
        private readonly IBaseRepository<Doctor> _doctorsRepository;

        public ChangeDoctorStatusCommandHandler(IBaseRepository<Doctor> doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        public async Task<Doctor> Handle(ChangeDoctorStatusCommand request, CancellationToken cancellationToken)
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
            return doctor;
        }
    }
}
