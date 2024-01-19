using Application.DTOs.Offices;
using Application.Resourses.Commands.Offices.Create;
using Application.Resourses.Queries.Offices;
using Domain.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.AppointmentsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class OfficesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfficesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-office")]
        public async Task<ActionResult<OfficeDto>> CreateOfficeAsync(CreateOfficeCommand command)
        {
            var office = await _mediator.Send(command);
            return Ok(office);
        }

        [HttpGet("offices")]
        public async Task<List<OfficeDto>> GetOfficesAsync([FromQuery] OfficeParameters officeParameters)
        {
            var offices = await _mediator.Send(new GetOfficesQuery
            {
                OfficeParameters = officeParameters
            });

            return offices;
        }
    }
}
