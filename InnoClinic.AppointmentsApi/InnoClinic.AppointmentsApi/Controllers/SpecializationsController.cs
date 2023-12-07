using Application.Resourses.Commands.Specializations;
using Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.AppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class SpecializationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SpecializationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-specialization")]
        public async Task<ActionResult<Specialization>> CreateSpecializationAsync(CreateSpecializationCommand command)
        {
            var specialization = await _mediator.Send(command);
            return Ok(specialization);
        }

        [HttpPut("change-specialization-status")]
        public async Task<ActionResult<Specialization>> ChangeSpecializationStatusAsync(ChangeSpecializationStatusCommand command)
        {
            var specialization = await _mediator.Send(command);
            return Ok(specialization);
        }

        [HttpPut("edit-specialization")]
        public async Task<ActionResult<Specialization>> UpdateSpecializationAsync(UpdateSpecializationCommand command)
        {
            var specialization = await _mediator.Send(command);
            return Ok(specialization);
        }
    }
}
