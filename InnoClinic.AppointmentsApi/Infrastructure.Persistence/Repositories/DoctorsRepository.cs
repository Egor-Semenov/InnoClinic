using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class DoctorsRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorsRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public Task<Doctor> GetDoctorById(int id, bool isTrackChanges) => isTrackChanges ?
            DbContext.Set<Doctor>().Where(x => x.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync() :
            DbContext.Set<Doctor>().Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        public async Task<PagedList<Doctor>> GetDoctors(DoctorParameters doctorParameters, bool isTrackChanges)
        {
            var doctorEntities = !isTrackChanges ?
                DbContext.Set<Doctor>().Include(x => x.Appointments).AsNoTracking() :
                DbContext.Set<Doctor>().Include(x => x.Appointments);

            var doctors = await doctorEntities.ToListAsync();

            var x = PagedList<Doctor>.ToPagedList(doctors, doctorParameters.PageNumber, doctorParameters.PageSize);

            return PagedList<Doctor>.ToPagedList(doctors, doctorParameters.PageNumber, doctorParameters.PageSize);
        }
    }
}
