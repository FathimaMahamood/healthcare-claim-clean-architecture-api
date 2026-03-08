
using HealthcareClaim.Application.Features.Claims.Queries.GetPagedClaims;
using HealthcareClaim.Application.Features.Patients.Commands.CreatePatient;
using HealthcareClaim.Application.Features.Patients.Queries.GetPagedlPatient;
using HealthcareClaim.Application.Features.Patients.Queries.GetPatientById;
using HealthcareClaim.Application.Features.Patients.Queries.GetPatientByPatientId;
using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePatientCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById),
                new { id },
                id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPatientByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(
                new GetPagedPatientQuery(pageNumber, pageSize));

            return Ok(result);
        }
        [HttpGet("by-patient-id/{patientId}")]
        public async Task<ActionResult<PatientResponse>> GetByPatientId(string patientId)
        {
            var result = await _mediator.Send(
                new GetPatientByPatientIdQuery { PatientId = patientId });

            return Ok(result);
        }
    }
}
