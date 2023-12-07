using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Appointments
{
    public sealed class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Appointment>
    {
        private readonly IBaseRepository<Appointment> _appointmentsRepository;

        public DeleteAppointmentCommandHandler(IBaseRepository<Appointment> appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task<Appointment> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            var appointment = await _appointmentsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();

            if (appointment is null)
            {
                throw new NotFoundException($"Appointment with id: {request.Id} is not found.");
            }

            await _appointmentsRepository.Delete(appointment!);
            return appointment!;
        }
    }
}
