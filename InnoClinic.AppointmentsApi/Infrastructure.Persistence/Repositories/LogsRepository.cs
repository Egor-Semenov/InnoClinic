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

        public Task Create(Log entity)
        {
            _dbContext.ChangeTracker.Clear();
            _dbContext.Logs.Add(entity);       
            return _dbContext.SaveChangesAsync();        
        }
    }
}
