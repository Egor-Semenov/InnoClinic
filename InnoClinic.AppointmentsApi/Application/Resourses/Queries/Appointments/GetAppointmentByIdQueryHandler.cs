using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Queries.Appointments
{
    public sealed class GetAppointmentByIdQueryHandler : IRequestHandler<GetAppointmentByIdQuery, Appointment>
    {
        private readonly IBaseRepository<Appointment> _appointmentsRepository;

        public GetAppointmentByIdQueryHandler(IBaseRepository<Appointment> appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public async Task<Appointment> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken) =>
            await _appointmentsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();
    }
}
