using Application.DTOs.Doctors;
using Application.DTOs.Patients;
using Application.DTOs.Receptionists;
using Application.RabbitMQ.Interfaces;
using Application.RabbitMQ.Models.Send;
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
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;

namespace InnoClinic.AppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserProfilesMessageProducer _messageProducer;

        public ProfilesController(IMediator mediator, IUserProfilesMessageProducer messageProducer)
        {
            _mediator = mediator;
            _messageProducer = messageProducer;
        }

        [HttpPost("create-doctor")]
        public async Task<IActionResult> CreateDoctorProfileAsync([FromBody] CreateDoctorDto createDoctorDto)
        {
            var doctor = await _mediator.Send(new CreateDoctorCommand
            {
                FirstName = createDoctorDto.FirstName,
                LastName = createDoctorDto.LastName,
                MiddleName = createDoctorDto.MiddleName,
                Email = createDoctorDto.Email,
                BirthDate = createDoctorDto.BirthDate,
                SpecializationId = createDoctorDto.SpecializationId,
                OfficeId = createDoctorDto.OfficeId,
                CareerStartYear = createDoctorDto.CareerStartDate,
                PhotoFilePath = createDoctorDto.PhotoFilePath
            });

            var message = new UserCreatedModel
            {
                UserId = doctor.UserId,
                Username = createDoctorDto.Username,
                Email = createDoctorDto.Email,
                Password = createDoctorDto.Password,
                Role = "Doctor"
            };
            _messageProducer.SendMessage(message);

            return Ok(createDoctorDto);
        }

        [HttpPut("edit-doctor/{id}")]
        public async Task<ActionResult> UpdateDoctorAsync(int id, [FromBody] UpdateDoctorDto updateDoctorDto)
        {
            var doctor = await _mediator.Send(new UpdateDoctorCommand
            {
                DoctorId = id,
                FirstName = updateDoctorDto.FirstName,
                LastName = updateDoctorDto.LastName,
                MiddleName = updateDoctorDto.MiddleName,
                Email = updateDoctorDto.Email,
                BirthDate = updateDoctorDto.BirthDate,
                SpecializationId = updateDoctorDto.SpecializationId,
                OfficeId = updateDoctorDto.OfficeId,
                CareerStartYear = updateDoctorDto.CareerStartYear,
                PhotoFilePath = updateDoctorDto.PhotoFilePath,
            });

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

        [HttpGet("doctors/{id}")]
        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doctor = await _mediator.Send(new GetDoctorByIdQuery
            {
                Id = id
            });

            return doctor;
        }

        [HttpPost("create-patient")]
        public async Task<IActionResult> CreatePatientProfileAsync([FromBody] CreatePatientDto createPatientDto)
        {
            var patient = await _mediator.Send(new CreatePatientCommand
            {
                FirstName = createPatientDto.FirstName,
                LastName = createPatientDto.LastName,
                MiddleName = createPatientDto.MiddleName,
                PhoneNumber = createPatientDto.PhoneNumber,
                BirthDate = createPatientDto.BirthDate,
                PhotoFilePath = createPatientDto.PhotoFilePath,
            });

            var message = new UserCreatedModel
            {
                UserId = patient.UserId,
                Username = createPatientDto.Username,
                Password = createPatientDto.Password,
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
        public async Task<ActionResult<DeletePatientDto>> DeletePatientAsync([FromQuery] DeletePatientCommand command)
        {
            var patient = await _mediator.Send(command);

            _messageProducer.SendMessage(new UserDeletedModel
            {
                UserId = patient.UserId,
                Role = "Patient"
            });

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

            _messageProducer.SendMessage(new UserCreatedModel
            {
                UserId = receptionist.UserId,
                Username = command.Username,
                Email = command.Email,
                Password = command.Password,
                Role = "Receptionist"
            });

            return Ok(receptionist);
        }

        [HttpPut("edit-receptionist")]
        public async Task<ActionResult<Receptionist>> UpdateReceptionistAsync([FromBody] UpdateReceptionistCommand command)
        {
            var receptionist = await _mediator.Send(command);
            return Ok(receptionist);
        }

        [HttpDelete("delete-receptionist")]
        public async Task<ActionResult<Receptionist>> DeleteReceptionistAsync([FromQuery] DeleteReceptionistCommand command)
        {
            var receptionist = await _mediator.Send(command);

            _messageProducer.SendMessage(new UserDeletedModel
            {
                UserId = receptionist.UserId,
                Role = "Receptionist"
            });

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
