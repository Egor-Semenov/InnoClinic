using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Appointments.Delete
{
    public sealed class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Appointment>
    {
        private readonly IBaseRepository<Appointment> _appointmentsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAppointmentCommandHandler(IBaseRepository<Appointment> appointmentsRepository, IUnitOfWork unitOfWork)
        {
            _appointmentsRepository = appointmentsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Appointment> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();

            if (appointment is null)
            {
                throw new NotFoundException($"Appointment with id: {request.Id} is not found.");
            }

            _appointmentsRepository.Delete(appointment!);
            await _unitOfWork.SaveChangesAsync();

            return appointment!;
        }
    }
}
