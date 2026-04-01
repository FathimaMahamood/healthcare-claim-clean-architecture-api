using HealthcareClaim.Application.Features.InsurancePolicies.Commands.CreateInsurancePolicy;
using HealthcareClaim.Application.Features.InsurancePolicies.Queries.GetInsurancePolicyById;
using HealthcareClaim.Application.Features.InsurancePolicies.Queries.GetPagedInsurancePolicy;
using HealthcareClaim.Application.Features.Patients.Queries.GetPagedPatient;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsurancePoliciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InsurancePoliciesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInsurancePolicyCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InsurancePolicyResponse>> GetById(Guid id)
        {
            var result = await _mediator.Send(
                new GetInsurancePolicyByIdQuery { Id = id });

            return Ok(result);
        }
        public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(
                new GetPagedInsurancePolicyQuery(pageNumber, pageSize));

            return Ok(result);
        }
    }
}
