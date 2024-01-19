using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using Domain.RequestFeatures.Extensions;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class OfficesRepository : BaseRepository<Office>, IOfficeRepository
    {
        public OfficesRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<List<Office>> GetOfficesAsync(OfficeParameters officeParameters, bool isTrackChanges)
        {
            var officeEntities = !isTrackChanges ?
                DbContext.Set<Office>().AsNoTracking() :
                DbContext.Set<Office>();

            var offices = await officeEntities
                .FilterByOfficeStatus(officeParameters.OfficeStatus)
                .Search(officeParameters.SearchTerm)
                .ToListAsync();

            return offices;
        }
    }
}
