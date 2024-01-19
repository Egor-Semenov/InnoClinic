namespace Domain.Models.Entities
{
    public sealed class Appointment : SoftDelete
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId {  get; set; }
        public int SpecializationId { get; set; }
        public int ServiceId { get; set; }
        public int OfficeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string? Description { get; set; }
        public int StatusId { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public AppointmentStatus Status { get; set; }
        public Specialization Specialization { get; set; }
        public Service Service { get; set; }
        public Office Office { get; set; }
    }
}
