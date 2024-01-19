using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public sealed class Office
    {
        public int OfficeId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string? OfficeNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int StatusId { get; set; }
        public string? PhotoFilePath { get; set; }
        
        [NotMapped]
        public string Address => $"{City}, {Street} - {HouseNumber}, office: {OfficeNumber}";

        public OfficeStatus OfficeStatus { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Receptionist> Receptionists { get; set;}
    }
}
