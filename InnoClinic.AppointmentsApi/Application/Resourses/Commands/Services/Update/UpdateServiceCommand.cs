using Application.DTOs.Services;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Services.Update
{
    public sealed class UpdateServiceCommand : IRequest<UpdateServiceDto>
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public ServiceCategories Category { get; set; }
    }
}
