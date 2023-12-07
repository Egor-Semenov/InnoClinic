using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class SpecializationsRepository : IBaseRepository<Specialization>
    {
        private readonly ApplicationDbContext _dbContext;

        public SpecializationsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Specialization entity)
        {
            _dbContext.Set<Specialization>().Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Specialization entity)
        {
            _dbContext.Set<Specialization>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<Specialization> FindAll(bool isTrackChanges) =>
            !isTrackChanges ?
        _dbContext.Set<Specialization>()
                .AsNoTracking() :
            _dbContext.Set<Specialization>();

        public IQueryable<Specialization> FindByCondition(Expression<Func<Specialization, bool>> expression, bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Specialization>()
        .Where(expression)
                .AsNoTracking() :
            _dbContext.Set<Specialization>()
            .Where(expression);

        public Task Update(Specialization entity)
        {
            _dbContext.Set<Specialization>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
