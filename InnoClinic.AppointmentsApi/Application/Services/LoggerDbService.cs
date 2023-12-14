using Application.Services.Interfaces;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public sealed class LoggerDbService : ILoggerDbService
    {
        private readonly ILogRepository _logsRepository;

        public LoggerDbService(ILogRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public async Task LogAsync(Exception ex)
        {
            await _logsRepository.Create(new()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                TimeStamp = DateTime.Now
            });
        }
    }
}
