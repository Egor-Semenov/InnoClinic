using Application.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Quartz;

namespace InnoClinic.BackgroundJobs.Jobs
{
    [DisallowConcurrentExecution]
    public sealed class DeleteJob : IJob
    {
        private readonly IConfiguration _configuration;
        private readonly ILoggerDbService _loggerService;

        public DeleteJob(IConfiguration configuration, ILoggerDbService loggerService)
        {
            _configuration = configuration;
            _loggerService = loggerService;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await ExecuteDeleteJob("Patients");
            await ExecuteDeleteJob("Receptionists");
            await ExecuteDeleteJob("Appointmnets");
        }

        private async Task ExecuteDeleteJob(string tableName)
        {
            var connection = new SqlConnection(_configuration.GetConnectionString("sqlConnection"));
            await connection.OpenAsync();

            var deleteCommand = $"DELETE FROM {tableName} WHERE IsDeleted = 1 AND DATEDIFF(MINUTE, DeletedAt, GETDATE()) >= 5";
            var command = new SqlCommand(deleteCommand, connection);

            try
            {
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                await _loggerService.LogAsync(ex);
            }
        }
    }
}
