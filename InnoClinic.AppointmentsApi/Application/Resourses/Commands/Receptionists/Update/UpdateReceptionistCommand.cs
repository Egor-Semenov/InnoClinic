using Application.DTOs.Receptionists;
using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Receptionists.Update
{
    public sealed class UpdateReceptionistCommand : IRequest<UpdateReceptionistDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public int OfficeId { get; set; }
    }
}
