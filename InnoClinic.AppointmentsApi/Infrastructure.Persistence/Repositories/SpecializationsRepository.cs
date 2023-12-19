using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class SpecializationsRepository : BaseRepository<Specialization>
    {
        public SpecializationsRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
