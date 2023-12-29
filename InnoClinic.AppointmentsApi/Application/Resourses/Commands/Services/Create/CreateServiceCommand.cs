using Application.DTOs.Services;
using Domain.Models.Enums;
using MediatR;

namespace Application.Resourses.Commands.Services.Create
{
    public sealed class CreateServiceCommand : IRequest<ServiceDto>
    {
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public int SpecializationId { get; set; }
        public ServiceCategories Category { get; set; }
    }
}
