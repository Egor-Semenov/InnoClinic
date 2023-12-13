using Application.DTOs.Receptionists;
using Domain.Models.Entities;
using MediatR;

namespace Application.Resourses.Commands.Receptionists.Delete
{
    public sealed class DeleteReceptionistCommand : IRequest<DeleteReceptionistDto>
    {
        public int Id { get; set; }
    }
}
