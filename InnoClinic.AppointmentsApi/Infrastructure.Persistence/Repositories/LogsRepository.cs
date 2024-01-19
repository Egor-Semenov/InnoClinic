using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class LogsRepository : ILogRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LogsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Log entity)
        {
            _dbContext.Logs.Add(entity);       
        }
    }
}
