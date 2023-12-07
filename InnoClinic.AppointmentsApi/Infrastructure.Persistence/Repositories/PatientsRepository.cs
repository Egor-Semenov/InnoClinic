using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class PatientsRepository : IBaseRepository<Patient>
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Patient entity)
        {
            _dbContext.Set<Patient>().Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Patient entity)
        {
            _dbContext.Set<Patient>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<Patient> FindAll(bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Patient>()
                .AsNoTracking() :
            _dbContext.Set<Patient>();

        public IQueryable<Patient> FindByCondition(Expression<Func<Patient, bool>> expression, bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Patient>()
                .Where(expression)
                .AsNoTracking() :
            _dbContext.Set<Patient>()
            .Where(expression);

        public Task Update(Patient entity)
        {
            _dbContext.Set<Patient>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
