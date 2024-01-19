using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using Domain.RequestFeatures.Extensions;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class ServicesRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServicesRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<List<Service>> GetServicesAsync(ServiceParameters serviceParameters, bool isTrackChanges)
        {
            var serviceEntities = !isTrackChanges ?
                DbContext.Set<Service>().AsNoTracking() :
                DbContext.Set<Service>();

            var services = await serviceEntities
                .FilterByServiceStatus(serviceParameters.ServiceStatus)
                .FilterBySpecialization(serviceParameters.SpecializationId)
                .FilterByServiceCategory(serviceParameters.ServiceCategory)
                .Search(serviceParameters.SearchTerm)
                .ToListAsync();

            return services;
        }
    }
}
