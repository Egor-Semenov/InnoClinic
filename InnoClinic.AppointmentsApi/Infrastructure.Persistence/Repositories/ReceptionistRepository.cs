using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class ReceptionistRepository : IBaseRepository<Receptionist>
    {
        private readonly ApplicationDbContext _dbContext;

        public ReceptionistRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Receptionist entity)
        {
            _dbContext.Set<Receptionist>().Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Receptionist entity)
        {
            _dbContext.Set<Receptionist>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<Receptionist> FindAll(bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Receptionist>()
                .AsNoTracking() :
            _dbContext.Set<Receptionist>();

        public IQueryable<Receptionist> FindByCondition(Expression<Func<Receptionist, bool>> expression, bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Receptionist>()
                .Where(expression)
                .AsNoTracking() :
            _dbContext.Set<Receptionist>()
            .Where(expression);

        public Task Update(Receptionist entity)
        {
            _dbContext.Set<Receptionist>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
