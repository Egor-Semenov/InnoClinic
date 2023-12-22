using Domain.Models.Entities;
using Domain.RequestFeatures;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IDoctorRepository : IBaseRepository<Doctor>
    {
        Task<Doctor> GetDoctorById(int id, bool isTrackChanges);
        Task<PagedList<Doctor>> GetDoctors(DoctorParameters doctorParameters, bool isTrackChanges);
    }
}
