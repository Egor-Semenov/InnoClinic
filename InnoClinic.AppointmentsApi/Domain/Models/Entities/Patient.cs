
namespace Domain.Models.Entities
{
    public sealed class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoFilePath { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
