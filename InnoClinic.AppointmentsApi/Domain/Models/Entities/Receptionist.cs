
namespace Domain.Models.Entities
{
    public sealed class Receptionist
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int OfficeId { get; set; }
    }
}
