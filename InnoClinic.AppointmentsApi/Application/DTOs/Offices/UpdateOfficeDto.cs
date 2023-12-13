using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Offices
{
    public sealed class UpdateOfficeDto
    {
        public int OfficeId { get; set; }
        public string OfficeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public OfficeStatuses Status { get; set; }
        public string PhotoFilePath { get; set; }
    }
}
