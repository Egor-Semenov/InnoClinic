using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using Domain.RequestFeatures.Extensions;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class AppointmentsRepository : BaseRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentsRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<PagedList<Appointment>> GetAppointmentsAsync(AppointmentParameters appointmentParameters, bool isTrackChanges)
        {
            var appointmentEntities = !isTrackChanges ?
                DbContext.Set<Appointment>().AsNoTracking() :
                DbContext.Set<Appointment>();

            var appointments = await appointmentEntities
                .FilterByAppointmentStatus(appointmentParameters.AppointmentStatus)
                .FilterByPatient(appointmentParameters.PatientId)
                .FilterByDoctor(appointmentParameters.DoctorId)
                .FilterBySpecialization(appointmentParameters.SpecializationId)
                .FilterByService(appointmentParameters.ServiceId)
                .FilterByOffice(appointmentParameters.OfficeId)
                .ToListAsync();

            return PagedList<Appointment>.ToPagedList(appointments, appointmentParameters.PageNumber, appointmentParameters.PageSize);
        }
    }
}
