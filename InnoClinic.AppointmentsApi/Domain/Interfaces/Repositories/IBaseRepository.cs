using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll(bool isTrackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTrackChanges);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
