using Application.DTOs.Patients;
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
    }
}
