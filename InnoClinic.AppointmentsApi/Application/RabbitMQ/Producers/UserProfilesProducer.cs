using Application.RabbitMQ.Interfaces;
using Application.RabbitMQ.Models.Send;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace Application.RabbitMQ.Producers
{
    public sealed class UserProfilesProducer : IUserProfilesMessageProducer
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public UserProfilesProducer() 
        {
            _factory = new ConnectionFactory { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.ConfirmSelect();
        }

        public void SendMessage(UserCreatedModel message)
        {
            var payload = JsonConvert.SerializeObject(message);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish("user-profiles", "user-created", null, byteArray);

            _channel.WaitForConfirmsOrDie(timeout: TimeSpan.FromSeconds(10));
        }

        public void SendMessage(UserDeletedModel message)
        {
            var payload = JsonConvert.SerializeObject(message);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            _channel.BasicPublish("user-profiles", "user-deleted", null, byteArray);
        }
    }
}
