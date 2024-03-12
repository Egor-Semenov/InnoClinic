
namespace Application.DTOs.Patients
{
    public sealed class DeletePatientDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
