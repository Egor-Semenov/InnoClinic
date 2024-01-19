using Application.Services.Interfaces;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public sealed class LoggerDbService : ILoggerDbService
    {
        private readonly ILogRepository _logsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public LoggerDbService(ILogRepository logsRepository, IUnitOfWork unitOfWork)
        {
            _logsRepository = logsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task LogAsync(Exception ex)
        {
            _unitOfWork.Rollback();

            _logsRepository.Create(new()
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                TimeStamp = DateTime.Now
            });

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
