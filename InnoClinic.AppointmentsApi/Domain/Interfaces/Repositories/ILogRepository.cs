using Domain.Models.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ILogRepository
    {
        void Create(Log entity);
    }
}
