using Domain.Models.Enums;

namespace Application.DTOs.Services
{
    public sealed class ChangeServiceStatusDto
    {
        public int Id { get; set; }
        public ServiceStatuses Status { get; set; }
    }
}
