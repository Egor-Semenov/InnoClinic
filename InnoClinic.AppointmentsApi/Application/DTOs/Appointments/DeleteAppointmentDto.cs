
namespace Application.DTOs.Appointments
{
    public sealed class DeleteAppointmentDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
