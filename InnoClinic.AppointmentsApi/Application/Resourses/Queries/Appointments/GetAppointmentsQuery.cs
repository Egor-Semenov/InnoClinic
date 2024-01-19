using Application.DTOs.Appointments;
using Domain.RequestFeatures;
using MediatR;

namespace Application.Resourses.Queries.Appointments
{
    public sealed class GetAppointmentsQuery : IRequest<PagedList<AppointmentDto>>
    {
        public AppointmentParameters AppointmentParameters { get; set; }
    }
}
