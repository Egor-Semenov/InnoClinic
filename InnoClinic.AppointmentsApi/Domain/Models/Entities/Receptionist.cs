namespace Domain.Models.Entities
{
    public sealed class Receptionist : SoftDelete
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public int OfficeId { get; set; }
        public string? PhotoFilePath { get; set; }

        public Office Office { get; set; }
    }
}
