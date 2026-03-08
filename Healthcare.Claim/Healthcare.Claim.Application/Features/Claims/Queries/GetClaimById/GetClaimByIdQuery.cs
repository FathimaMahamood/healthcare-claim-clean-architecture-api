using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetClaimById
{
    public record GetClaimByIdQuery(Guid Id) : IRequest<ClaimResponse?>;
}
