using Application.DTOs.Patients;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Patients
{
    public sealed class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, PagedList<PatientDto>>
    {
        private readonly IPatientRepository _patientsRepository;
        private readonly IMapper _mapper;

        public GetPatientsQueryHandler(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientsRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<PatientDto>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            var patients = await _patientsRepository.GetPatientsAsync(request.PatientParameters, false);

            var patientsDto = _mapper.Map<List<PatientDto>>(patients);
            return new PagedList<PatientDto>(patientsDto, patients.MetaData.TotalCount, patients.MetaData.CurrentPage, patients.MetaData.PageSize);
        }
    }
}
