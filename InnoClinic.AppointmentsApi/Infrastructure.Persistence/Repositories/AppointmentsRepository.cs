using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class AppointmentsRepository : BaseRepository<Appointment>
    {
        public AppointmentsRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
