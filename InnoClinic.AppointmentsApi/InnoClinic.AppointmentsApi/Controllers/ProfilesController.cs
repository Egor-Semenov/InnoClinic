using Application.Resourses.Commands.Doctors;
using Application.Resourses.Commands.Patients;
using Application.Resourses.Commands.Receptionists;
using Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.AppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-doctor")]
        public async Task<IActionResult> CreateDoctorProfileAsync([FromBody] CreateDoctorCommand command)
        {
            await _mediator.Send(command);
            return Ok(command);
        }

        [HttpPut("edit-doctor")]
        public async Task<ActionResult<Doctor>> UpdateDoctorAsync([FromBody] UpdateDoctorCommand command)
        {
            var doctor = await _mediator.Send(command);
            return Ok(doctor);
        }

        [HttpPut("change-doctor-status")]
        public async Task<ActionResult<Doctor>> ChangeDoctorStatusAsync([FromBody] ChangeDoctorStatusCommand command)
        {
            var doctor = await _mediator.Send(command);
            return Ok(doctor);
        }

        [HttpPost("create-patient")]
        public async Task<IActionResult> CreatePatientProfileAsync([FromBody] CreatePatientCommand command)
        {
            var patient = await _mediator.Send(command);
            return Ok(patient);
        }

        [HttpPut("edit-patient")]
        public async Task<ActionResult<Patient>> UpdatePatientAsync([FromBody] UpdatePatientCommand command)
        {
            var patient = await _mediator.Send(command);
            return Ok(patient);
        }

        [HttpDelete("delete-patient")]
        public async Task<ActionResult<Patient>> DeletePatientAsync([FromBody] DeletePatientCommand command)
        {
            var patient = await _mediator.Send(command);
            return Ok(patient);
        }

        [HttpPost("create-receptionist")]
        public async Task<IActionResult> CreateReceptionistProfileAsync([FromBody] CreateReceptionistCommand command)
        {
            var receptionist = await _mediator.Send(command);           
            return Ok(receptionist);
        }

        [HttpPut("edit-receptionist")]
        public async Task<ActionResult<Receptionist>> UpdateReceptionistAsync([FromBody] UpdateReceptionistCommand command)
        {
            var receptionist = await _mediator.Send(command);
            return Ok(receptionist);
        }

        [HttpDelete("delete-receptionist")]
        public async Task<ActionResult<Receptionist>> DeleteReceptionistAsync([FromBody] DeleteReceptionistCommand command)
        {
            var receptionist = await _mediator.Send(command);
            return Ok(receptionist);
        }
    }
}
