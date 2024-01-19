using Domain.Models.Entities;
using Domain.RequestFeatures;

namespace Domain.Interfaces.Repositories
{
    public interface IPatientRepository : IBaseRepository<Patient>
    {
        Task<PagedList<Patient>> GetPatientsAsync(PatientParameters patientParameters, bool isTrackChanges);
    }
}
