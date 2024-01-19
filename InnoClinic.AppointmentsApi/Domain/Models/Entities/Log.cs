namespace Domain.Models.Entities
{
    public sealed class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
