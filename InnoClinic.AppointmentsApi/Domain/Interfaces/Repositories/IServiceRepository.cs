using Domain.Models.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces.Repositories
{
    public interface IServiceRepository : IBaseRepository<Service>
    {
        Task<List<Service>> GetServicesAsync(ServiceParameters serviceParameters, bool isTrackChanges);
    }
}
