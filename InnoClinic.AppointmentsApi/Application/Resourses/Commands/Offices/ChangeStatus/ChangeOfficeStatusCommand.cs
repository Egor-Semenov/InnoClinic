using Application.DTOs.Offices;
using Domain.Models.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Commands.Offices.ChangeStatus
{
    public sealed class ChangeOfficeStatusCommand : IRequest<ChangeOfficeStatusDto>
    {
        public int OfficeId { get; set; }
        public OfficeStatuses Status { get; set; }
    }
}
