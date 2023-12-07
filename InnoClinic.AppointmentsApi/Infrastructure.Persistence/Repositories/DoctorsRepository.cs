using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class DoctorsRepository : IBaseRepository<Doctor>
    {
        private readonly ApplicationDbContext _dbContext;

        public DoctorsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Doctor entity)
        {
            _dbContext.Set<Doctor>().Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Doctor entity)
        {
            _dbContext.Set<Doctor>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<Doctor> FindAll(bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Doctor>()
                .AsNoTracking() :
            _dbContext.Set<Doctor>();

        public IQueryable<Doctor> FindByCondition(Expression<Func<Doctor, bool>> expression, bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Doctor>()
                .Where(expression)
                .AsNoTracking() :
            _dbContext.Set<Doctor>()
            .Where(expression);

        public Task Update(Doctor entity)
        {
            _dbContext.Set<Doctor>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
