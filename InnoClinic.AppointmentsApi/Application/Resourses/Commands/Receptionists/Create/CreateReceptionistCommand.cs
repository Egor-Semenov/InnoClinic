using Application.DTOs.Receptionists;
using MediatR;

namespace Application.Resourses.Commands.Receptionists.Create
{
    public sealed class CreateReceptionistCommand : IRequest<ReceptionistDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int OfficeId { get; set; }
    }
}
