using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Commands.Services
{
    public sealed class CreateServiceCommand : IRequest<Service>
    {
        public string ServiceName { get; set; }
        public double Price { get; set; }
        public ServiceCategories Category { get; set; }
    }
}
