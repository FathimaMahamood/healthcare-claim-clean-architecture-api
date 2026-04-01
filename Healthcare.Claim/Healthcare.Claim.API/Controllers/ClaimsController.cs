using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Features.Claims.Commands.CreateClaim;
using HealthcareClaim.Application.Features.Claims.Commands.UploadClaimAttachment;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimAttachmentsQuery;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimsByPatientId;
using HealthcareClaim.Application.Features.Claims.Queries.GetPagedClaims;
using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClaimsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateClaimCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetClaimByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatientId(Guid patientId)
        {
            var result = await _mediator.Send(
                new GetClaimsByPatientIdQuery(patientId));

            return Ok(result);
        }
        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(  [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(
                new GetPagedClaimsQuery(pageNumber, pageSize));

            return Ok(result);
        }

        [HttpPost("{claimId}/attachments")]
        public async Task<IActionResult> Upload(Guid claimId,IFormFile file)
        {
            await _mediator.Send(new UploadClaimAttachmentCommand
            {
                ClaimId = claimId,
                File = file
            });

            return Ok("File uploaded");
        }
        [HttpGet("{claimId}/attachments")]
        public async Task<IActionResult> GetAttachments(Guid claimId)
        {
            var result = await _mediator.Send(
                new GetClaimAttachmentsQuery { ClaimId = claimId });

            return Ok(result);
        }


    }
}
