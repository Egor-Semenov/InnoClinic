namespace Application.RabbitMQ.Models.Send
{
    public sealed class UserDeletedModel
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }
    }
}
