using Application.DTOs.Doctors;
using Application.DTOs.Patients;
using Application.DTOs.Receptionists;
using Application.RabbitMQ.Interfaces;
using Application.RabbitMQ.Models;
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
using Application.Resourses.Queries.Patients;
using Application.Resourses.Queries.Receptionists;
using Domain.Models.Entities;
using Domain.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InnoClinic.AppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMessageProducer _messageProducer;

        public ProfilesController(IMediator mediator, IMessageProducer messageProducer)
        {
            _mediator = mediator;
            _messageProducer = messageProducer;
        }

        [HttpPost("create-doctor")]
        public async Task<IActionResult> CreateDoctorProfileAsync([FromBody] CreateDoctorCommand command)
        {
            await _mediator.Send(command);

            var message = new UserCreatedModel
            {
                Username = command.Username,
                Password = command.Password,
                Role = "Doctor"
            };
            _messageProducer.SendMessage(message);

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

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(doctors.MetaData));

            return doctors;
        }

        [HttpPost("create-patient")]
        public async Task<IActionResult> CreatePatientProfileAsync([FromBody] CreatePatientDto command)
        {
            var patient = await _mediator.Send(new CreatePatientCommand
            {
                Username = command.Username,
                FirstName = command.FirstName,
                LastName = command.LastName,
                MiddleName = command.MiddleName,
                PhoneNumber = command.PhoneNumber,
                BirthDate = command.BirthDate,
                PhotoFilePath = command.PhotoFilePath,
            });

            var message = new UserCreatedModel
            {
                Username = command.Username,
                Password = command.Password,
                Role = "Patient"
            };
            _messageProducer.SendMessage(message);

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

        [HttpGet("patients")]
        public async Task<PagedList<PatientDto>> GetPatientsAsync([FromQuery] PatientParameters patientParameters)
        {
            var patients = await _mediator.Send(new GetPatientsQuery
            {
                PatientParameters = patientParameters
            });

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(patients.MetaData));

            return patients;
        }

        [HttpPost("create-receptionist")]
        public async Task<IActionResult> CreateReceptionistProfileAsync([FromBody] CreateReceptionistCommand command)
        {
            var receptionist = await _mediator.Send(command);

            var message = new UserCreatedModel
            {
                Username = command.Username,
                Password = command.Password,
                Role = "Receptionist"
            };
            _messageProducer.SendMessage(message);

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

        [HttpGet("receptionists")]
        public async Task<PagedList<ReceptionistDto>> GetReceptionistsAsync([FromQuery] ReceptionistParameters receptionistParameters)
        {
            var receptionists = await _mediator.Send(new GetReceptionistsQuery
            {
                ReceptionistParameters = receptionistParameters
            });

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(receptionists.MetaData));

            return receptionists;
        }
    }
}
