using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetPagedClaims
{
    public record GetPagedClaimsQuery( int PageNumber = 1, int PageSize = 10 ) : IRequest<PagedResult<ClaimResponse>>;
}
