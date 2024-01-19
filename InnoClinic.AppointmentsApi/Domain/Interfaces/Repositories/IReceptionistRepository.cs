using Domain.Models.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces.Repositories
{
    public interface IReceptionistRepository : IBaseRepository<Receptionist>
    {
        Task<PagedList<Receptionist>> GetReceptionistsAsync(ReceptionistParameters receptionistParameters, bool isTrackChanges);
    }
}
