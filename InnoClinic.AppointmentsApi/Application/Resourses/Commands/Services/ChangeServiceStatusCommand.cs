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
    public sealed class ChangeServiceStatusCommand : IRequest<Service>
    {
        public int Id { get; set; }
        public ServiceStatuses Status { get; set; }
    }
}
