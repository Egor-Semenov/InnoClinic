using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class ServicesRepository : BaseRepository<Service>
    {
        public ServicesRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
