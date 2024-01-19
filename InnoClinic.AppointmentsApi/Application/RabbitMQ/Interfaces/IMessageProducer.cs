namespace Application.RabbitMQ.Interfaces
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
