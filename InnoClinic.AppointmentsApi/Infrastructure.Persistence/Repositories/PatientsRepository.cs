using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using Domain.RequestFeatures.Extensions;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class PatientsRepository : BaseRepository<Patient>, IPatientRepository
    {
        public PatientsRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<PagedList<Patient>> GetPatientsAsync(PatientParameters patientParameters, bool isTrackChanges)
        {
            var patientEntities = !isTrackChanges ?
                DbContext.Set<Patient>().AsNoTracking() :
                DbContext.Set<Patient>();

            var patients = await patientEntities
                .Search(patientParameters.SearchTerm)
                .ToListAsync();

            return PagedList<Patient>.ToPagedList(patients, patientParameters.PageNumber, patientParameters.PageSize);
        }
    }
}
