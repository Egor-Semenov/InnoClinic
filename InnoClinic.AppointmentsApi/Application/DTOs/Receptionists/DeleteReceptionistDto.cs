
namespace Application.DTOs.Receptionists
{
    public sealed class DeleteReceptionistDto
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
