using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Offices
{
    public sealed class ChangeOfficeStatusDto
    {
        public int OfficeId { get; set; }
        public OfficeStatuses Status { get; set; }
    }
}
