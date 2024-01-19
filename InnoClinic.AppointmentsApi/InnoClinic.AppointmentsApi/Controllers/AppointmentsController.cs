using Application.DTOs.Appointments;
using Application.Resourses.Commands.Appointments.Approve;
using Application.Resourses.Commands.Appointments.Create;
using Application.Resourses.Commands.Appointments.Delete;
using Application.Resourses.Queries.Appointments;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InnoClinic.AppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-appointment")]
        public async Task<IActionResult> CreateAppointmentAsync([FromBody] CreateAppointmentCommand command)
        {
            var appointment = await _mediator.Send(command);
            return Ok(appointment);
        }

        [HttpPut("approve-appointment")]
        public async Task<IActionResult> ApproveAppointmentAsync([FromBody] ApproveAppointmentCommand command)
        {
            var appointment = await _mediator.Send(command);
            return Ok(appointment);
        }

        [HttpDelete("cancel-appointment")]
        public async Task<IActionResult> CancelAppointmentAsync([FromBody] DeleteAppointmentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("appointment")]
        public async Task<Appointment> GetAppointmentByIdAsync([FromQuery] GetAppointmentByIdQuery query)
        {
            var appointment = await _mediator.Send(query);
            return appointment;
        }

        [HttpGet("appointments")]
        public async Task<PagedList<AppointmentDto>> GetAppointmentsAsync([FromQuery] AppointmentParameters appointmentParameters)
        {
            var appointments = await _mediator.Send(new GetAppointmentsQuery
            {
                AppointmentParameters = appointmentParameters
            });

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(appointments.MetaData));

            return appointments;
        }
    }
}
