using Domain.Models.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ILogRepository
    {
        Task Create(Log entity);
    }
}
