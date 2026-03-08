using HealthcareClaim.Application.Features.Claims.Commands.CreateClaim;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using HealthcareClaim.Application.Features.Claims.Queries.GetPagedClaims;
using HealthcareClaim.Application.Features.Providers.Commands.CreateProvider;
using HealthcareClaim.Application.Features.Providers.Queries.GetPagedProviders;
using HealthcareClaim.Application.Features.Providers.Queries.GetProviderById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProvidersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProviderCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetProviderByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(
                new GetPagedProvidersQuery(pageNumber, pageSize));

            return Ok(result);
        }
    }
}
