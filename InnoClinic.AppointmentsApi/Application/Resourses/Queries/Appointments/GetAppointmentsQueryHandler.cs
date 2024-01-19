using Application.DTOs.Appointments;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Appointments
{
    public sealed class GetAppointmentsQueryHandler : IRequestHandler<GetAppointmentsQuery, PagedList<AppointmentDto>>
    {
        private readonly IAppointmentRepository _appointmentsRepository;
        private readonly IMapper _mapper;

        public GetAppointmentsQueryHandler(IAppointmentRepository appointmentsRepository, IMapper mapper)
        {
            _appointmentsRepository = appointmentsRepository;
            _mapper = mapper;
        }

        public async Task<PagedList<AppointmentDto>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
        {
            var appointments = await _appointmentsRepository.GetAppointmentsAsync(request.AppointmentParameters, false);

            var appointmentsDto = _mapper.Map<List<AppointmentDto>>(appointments);
            return new PagedList<AppointmentDto>(appointmentsDto, appointments.MetaData.TotalCount, appointments.MetaData.CurrentPage, appointments.MetaData.PageSize);
        }
    }
}
