using Application.RabbitMQ.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Application.RabbitMQ.Producers
{
    public sealed class UserProfilesProducer : IMessageProducer
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public UserProfilesProducer() 
        {
            _factory = new ConnectionFactory { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void SendMessage<T>(T message)
        {
            var payload = JsonConvert.SerializeObject(message);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish("create-user", "user-created", null, byteArray);
        }
    }
}
