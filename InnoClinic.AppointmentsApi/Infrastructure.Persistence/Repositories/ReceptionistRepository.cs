using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using Domain.RequestFeatures.Extensions;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class ReceptionistRepository : BaseRepository<Receptionist>, IReceptionistRepository
    {
        public ReceptionistRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<PagedList<Receptionist>> GetReceptionistsAsync(ReceptionistParameters receptionistParameters, bool isTrackChanges)
        {
            var receptionistEntities = !isTrackChanges ?
                DbContext.Set<Receptionist>().AsNoTracking() :
                DbContext.Set<Receptionist>();

            var receptionists = await receptionistEntities
                .FilterByOffice(receptionistParameters.OfficeId)
                .Search(receptionistParameters.SearchTerm)
                .ToListAsync();

            return PagedList<Receptionist>.ToPagedList(receptionists, receptionistParameters.PageNumber, receptionistParameters.PageSize);
        }
    }
}
