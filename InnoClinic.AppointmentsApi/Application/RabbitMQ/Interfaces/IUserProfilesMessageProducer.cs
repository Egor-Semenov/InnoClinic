using Application.RabbitMQ.Models.Send;

namespace Application.RabbitMQ.Interfaces
{
    public interface IUserProfilesMessageProducer
    {
        void SendMessage(UserCreatedModel message);
        void SendMessage(UserDeletedModel message);
    }
}
