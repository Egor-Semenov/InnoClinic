using Domain.Models.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces.Repositories
{
    public interface IOfficeRepository : IBaseRepository<Office>
    {
        Task<List<Office>> GetOfficesAsync(OfficeParameters officeParameters, bool isTrackChanges);
    }
}
