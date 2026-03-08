using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Commands.CreateClaim
{
    public record CreateClaimCommand(Guid PatientId,Guid ProviderId, decimal ClaimAmount, string Description ) : IRequest<Guid>;
}
