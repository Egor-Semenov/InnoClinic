using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class ServicesRepository : IBaseRepository<Service>
    {
        private readonly ApplicationDbContext _dbContext;

        public ServicesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Service entity)
        {
            _dbContext.Set<Service>().Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Service entity)
        {
            _dbContext.Set<Service>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<Service> FindAll(bool isTrackChanges) =>
            !isTrackChanges ?
        _dbContext.Set<Service>()
                .AsNoTracking() :
            _dbContext.Set<Service>();

        public IQueryable<Service> FindByCondition(Expression<Func<Service, bool>> expression, bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Service>()
        .Where(expression)
                .AsNoTracking() :
            _dbContext.Set<Service>()
            .Where(expression);

        public Task Update(Service entity)
        {
            _dbContext.Set<Service>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
