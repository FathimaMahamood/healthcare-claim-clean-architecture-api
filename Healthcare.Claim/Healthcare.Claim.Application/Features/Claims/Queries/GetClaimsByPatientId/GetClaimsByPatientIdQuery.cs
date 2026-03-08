using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetClaimsByPatientId
{
    public record GetClaimsByPatientIdQuery(Guid PatientId)
    : IRequest<List<ClaimResponse>>;
}
