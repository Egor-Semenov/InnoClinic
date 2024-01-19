using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using Domain.RequestFeatures.Extensions;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class SpecializationsRepository : BaseRepository<Specialization>, ISpecializationRepository
    {
        public SpecializationsRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<List<Specialization>> GetSpecializationsAsync(SpecializationParameters specializationParameters, bool isTrackChanges)
        {
            var specializationEntities = !isTrackChanges ?
                DbContext.Set<Specialization>().AsNoTracking() :
                DbContext.Set<Specialization>();

            var specializations = await specializationEntities
                .FilterBySpecializationStatus(specializationParameters.SpecializationStatus)
                .Search(specializationParameters.SearchTerm)
                .ToListAsync();

            return specializations;
        }
    }
}
