using Domain.Models.Enums;

namespace Application.DTOs.Doctors
{
    public sealed class ChangeDoctorStatusDto
    {
        public int Id { get; set; }
        public DoctorsStatuses Status { get; set; }
    }
}
