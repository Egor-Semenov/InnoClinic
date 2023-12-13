using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class OfficesRepository : IBaseRepository<Office>
    {
        private readonly ApplicationDbContext _dbContext;

        public OfficesRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Office entity)
        {
            _dbContext.Set<Office>().Add(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task Delete(Office entity)
        {
            _dbContext.Set<Office>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public IQueryable<Office> FindAll(bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Office>()
                .AsNoTracking() :
            _dbContext.Set<Office>();

        public IQueryable<Office> FindByCondition(Expression<Func<Office, bool>> expression, bool isTrackChanges) =>
            !isTrackChanges ?
                _dbContext.Set<Office>()
                .Where(expression)
                .AsNoTracking() :
            _dbContext.Set<Office>()
            .Where(expression);

        public Task Update(Office entity)
        {
            _dbContext.Set<Office>().Update(entity);
            return _dbContext.SaveChangesAsync();
        }
    }
}
