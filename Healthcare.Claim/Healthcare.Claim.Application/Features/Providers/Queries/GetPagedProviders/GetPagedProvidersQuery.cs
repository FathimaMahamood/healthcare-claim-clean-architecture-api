using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using HealthcareClaim.Application.Features.Providers.Queries.GetProviderById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Providers.Queries.GetPagedProviders
{
    
    public record GetPagedProvidersQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<ProviderResponse>>;

}
