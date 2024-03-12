using Application.DTOs.Doctors;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Doctors
{
    public sealed class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, PagedList<DoctorDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDoctorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<DoctorDto>> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _unitOfWork.DoctorsRepository.GetDoctorsAsync(request.DoctorParameters, false);

            var doctorsDto = _mapper.Map<List<DoctorDto>>(doctors);
            return new PagedList<DoctorDto>(doctorsDto, doctors.MetaData.TotalCount, doctors.MetaData.CurrentPage, doctors.MetaData.PageSize);
        }
    }
}
