namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken token = default);
        void Rollback();
    }
}
