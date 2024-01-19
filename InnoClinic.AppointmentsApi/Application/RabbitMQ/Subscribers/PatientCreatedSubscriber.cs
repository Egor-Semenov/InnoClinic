using Application.Resourses.Commands.Patients.Create;
using Application.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Application.RabbitMQ.Subscribers
{
    public sealed class PatientCreatedSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IServiceScopeFactory _scopeFactory;

        private const string Queue = "user-profiles-service/patient-created";

        public PatientCreatedSubscriber(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;

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
                var message = JsonConvert.DeserializeObject<CreatePatientCommand>(contentString);

                using var scope = _scopeFactory.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var loggerService = scope.ServiceProvider.GetRequiredService<ILoggerDbService>();

                try
                {
                    await mediator.Send(message!);
                }
                catch (Exception ex)
                {
                    await loggerService.LogAsync(ex);
                }

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }
    }
}
