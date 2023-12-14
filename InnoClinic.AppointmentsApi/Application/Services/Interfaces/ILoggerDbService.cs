
namespace Application.Services.Interfaces
{
    public interface ILoggerDbService
    {
        public Task LogAsync(Exception ex);
    }
}
