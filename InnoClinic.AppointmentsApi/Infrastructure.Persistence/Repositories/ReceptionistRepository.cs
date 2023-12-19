using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class ReceptionistRepository : BaseRepository<Receptionist>
    {
        public ReceptionistRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
