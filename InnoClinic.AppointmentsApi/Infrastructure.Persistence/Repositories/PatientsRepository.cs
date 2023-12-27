using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class PatientsRepository : BaseRepository<Patient>
    {
        public PatientsRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
