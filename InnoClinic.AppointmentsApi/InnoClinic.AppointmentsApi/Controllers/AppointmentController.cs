using Application.Resourses.Commands.Appointments;
using Application.Resourses.Queries.Appointments;
using Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.AppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentCommand command)
        {
            Appointment appointment = await _mediator.Send(command);
            return Ok(appointment);
        }

        [HttpDelete]
        public async Task<IActionResult> CancelAppointment([FromBody] DeleteAppointmentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<Appointment> GetAppointmentByIdAsync([FromQuery] GetAppointmentByIdQuery query)
        {
            var appointment = await _mediator.Send(query);
            return appointment;
        }
    }
}
