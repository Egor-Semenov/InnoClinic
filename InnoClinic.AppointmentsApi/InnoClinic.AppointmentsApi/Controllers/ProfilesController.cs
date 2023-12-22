using Application.DTOs.Doctors;
using Application.Resourses.Commands.Doctors.ChangeStatus;
using Application.Resourses.Commands.Doctors.Create;
using Application.Resourses.Commands.Doctors.Update;
using Application.Resourses.Commands.Patients.Create;
using Application.Resourses.Commands.Patients.Delete;
using Application.Resourses.Commands.Patients.Update;
using Application.Resourses.Commands.Receptionists.Create;
using Application.Resourses.Commands.Receptionists.Delete;
using Application.Resourses.Commands.Receptionists.Update;
using Application.Resourses.Queries.Doctors;
using Domain.Models.Entities;
using Domain.RequestFeatures;
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

        [HttpGet("doctors")]
        public async Task<PagedList<DoctorDto>> GetDoctors([FromQuery] DoctorParameters doctorParameters)
        {
            var doctors = await _mediator.Send(new GetDoctorsQuery
            {
                DoctorParameters = doctorParameters
            });

            return doctors;
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
