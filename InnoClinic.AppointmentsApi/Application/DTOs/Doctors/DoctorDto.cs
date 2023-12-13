using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Doctors
{
    public sealed class DoctorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public int OfficeId { get; set; }
        public string Expirience { get; set; }
        public DoctorsStatuses Status { get; set; }
        public string PhotoFilePath { get; set; }
    }
}
