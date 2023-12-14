
namespace Domain.Interfaces.SoftDelete
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
