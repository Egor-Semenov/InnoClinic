using Application.DTOs.Doctors;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Resourses.Queries.Doctors
{
    public sealed class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, PagedList<DoctorDto>>
    {
        private readonly IDoctorRepository _doctorsRepository;
        private readonly IMapper _mapper;

        public GetDoctorsQueryHandler(IDoctorRepository doctorsRepository, IMapper mapper)
        {
            _doctorsRepository = doctorsRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorsRepository.GetDoctors(request.DoctorParameters, false);

            return _mapper.Map<PagedList<DoctorDto>>(doctors);
        }
    }
}
