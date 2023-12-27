using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll(bool isTrackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool isTrackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
