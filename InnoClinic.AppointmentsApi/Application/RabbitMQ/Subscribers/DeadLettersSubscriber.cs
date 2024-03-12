using Application.RabbitMQ.Models.Send;
using Application.Services.Interfaces;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Application.RabbitMQ.Subscribers
{
    public sealed class DeadLettersSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerDbService _loggerDbService;
        
        private const string Queue = "dlxqueue";
        public DeadLettersSubscriber(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;

            _unitOfWork = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<IUnitOfWork>();
            _loggerDbService = scopeFactory.CreateScope().ServiceProvider.GetRequiredService<ILoggerDbService>();

            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection();

            _channel = _connection.CreateModel();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);

                if (eventArgs.RoutingKey == "user-deleted")
                {
                    var message = JsonConvert.DeserializeObject<UserDeletedModel>(contentString);
                    try
                    {
                        switch (message.Role)
                        {
                            case "Patient":
                                var patient = await _unitOfWork.PatientsRepository.FindByCondition(x => x.UserId == message.UserId, false).IgnoreQueryFilters().FirstOrDefaultAsync();
                                patient.IsDeleted = false;
                                patient.DeletedAt = null;
                                _unitOfWork.PatientsRepository.Update(patient);
                                break;
                            case "Receptionist":
                                var receptionist = await _unitOfWork.ReceptionistsRepository.FindByCondition(x => x.UserId == message.UserId, false).IgnoreQueryFilters().FirstOrDefaultAsync();
                                receptionist.IsDeleted = false;
                                receptionist.DeletedAt = null;
                                _unitOfWork.ReceptionistsRepository.Update(receptionist);
                                break;
                        }

                        await _unitOfWork.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        await _loggerDbService.LogAsync(ex);
                    }
                }

                if (eventArgs.RoutingKey == "user-created")
                {
                    var message = JsonConvert.DeserializeObject<UserCreatedModel>(contentString);
                    try
                    {
                        switch (message.Role)
                        {
                            case "Patient":
                                var patient = await _unitOfWork.PatientsRepository.FindByCondition(x => x.UserId == message.UserId, false).FirstOrDefaultAsync();
                                _unitOfWork.PatientsRepository.Delete(patient);
                                break;
                            case "Receptionist":
                                var receptionist = await _unitOfWork.ReceptionistsRepository.FindByCondition(x => x.UserId == message.UserId, false).FirstOrDefaultAsync();
                                _unitOfWork.ReceptionistsRepository.Delete(receptionist);
                                break;
                        }

                        await _unitOfWork.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        await _loggerDbService.LogAsync(ex);
                    }
                }
            };
            _channel.BasicConsume(Queue, false, consumer);
            return Task.CompletedTask;
        }
    }
}
