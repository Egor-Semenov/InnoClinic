using Domain.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Commands.Services
{
    public sealed class UpdateServiceCommand : IRequest<Service>
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public double Price { get; set; }
    }
}
