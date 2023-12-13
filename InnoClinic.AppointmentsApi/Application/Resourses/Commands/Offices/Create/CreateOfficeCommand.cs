using Application.DTOs.Offices;
using Domain.Models.Entities;
using Domain.Models.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Commands.Offices.Create
{
    public sealed class CreateOfficeCommand : IRequest<OfficeDto>
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string OfficeNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoFilePath { get; set; }
    }
}
