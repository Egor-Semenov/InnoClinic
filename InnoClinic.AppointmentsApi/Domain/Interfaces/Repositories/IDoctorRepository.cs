using Domain.Models.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces.Repositories
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<Doctor> GetDoctorById(int id, bool isTrackChanges);
        Task<PagedList<Doctor>> GetDoctorsAsync(DoctorParameters doctorParameters, bool isTrackChanges);
    }
}
