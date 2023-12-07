using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Receptionists
{
    public sealed class DeleteReceptionistCommand : IRequest<Receptionist>
    {
        public int Id { get; set; }
    }
}
