using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class OfficesRepository : BaseRepository<Office>
    {
        public OfficesRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
