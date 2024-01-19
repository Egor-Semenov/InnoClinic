namespace Application.RabbitMQ.Models
{
    public sealed class UserCreatedModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
