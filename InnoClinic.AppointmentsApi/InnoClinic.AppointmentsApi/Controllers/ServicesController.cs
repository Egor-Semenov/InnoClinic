using Application.DTOs.Services;
using Application.Resourses.Commands.Services.ChangeStatus;
using Application.Resourses.Commands.Services.Create;
using Application.Resourses.Commands.Services.Update;
using Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.AppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-service")]
        public async Task<ActionResult<ServiceDto>> CreateServiceAsync(CreateServiceCommand command)
        {
            var service = await _mediator.Send(command);
            return Ok(service);
        }

        [HttpPut("change-service-status")]
        public async Task<ActionResult<Service>> ChangeServiceStatusAsync(ChangeServiceStatusCommand command)
        {
            var service = await _mediator.Send(command);
            return Ok(service);
        }

        [HttpPut("edit-service")]
        public async Task<ActionResult<Service>> UpdateServiceAsync(UpdateServiceCommand command)
        {
            var service = await _mediator.Send(command);
            return Ok(service);
        }
    }
}
