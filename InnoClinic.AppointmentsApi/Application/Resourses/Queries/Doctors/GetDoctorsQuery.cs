using Application.DTOs.Doctors;
using Domain.RequestFeatures;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Queries.Doctors
{
    public sealed class GetDoctorsQuery : IRequest<PagedList<DoctorDto>>
    {
        public DoctorParameters DoctorParameters { get; set; }
    }
}
