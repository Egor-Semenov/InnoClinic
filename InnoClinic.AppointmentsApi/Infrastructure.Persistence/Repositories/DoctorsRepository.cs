using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class DoctorsRepository : BaseRepository<Doctor>
    {
        public DoctorsRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
