using Domain.Interfaces.Repositories;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext DbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Create(T entity) => DbContext.Set<T>().Add(entity);

        public void Delete(T entity) => DbContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool isTrackChanges) => !isTrackChanges ?
            DbContext.Set<T>().AsNoTracking() :
            DbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTrackChanges) => !isTrackChanges ?
            DbContext.Set<T>().Where(expression).AsNoTracking() :
            DbContext.Set<T>().Where(expression);

        public void Update(T entity) => DbContext.Set<T>().Update(entity);
    }
}
