using Domain.Models.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces.Repositories
{
    public interface ISpecializationRepository : IBaseRepository<Specialization>
    {
        Task<List<Specialization>> GetSpecializationsAsync(SpecializationParameters specializationParameters, bool isTrackChanges);
    }
}
