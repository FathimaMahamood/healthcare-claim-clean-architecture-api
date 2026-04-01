using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Commands.RejectClaim
{
    public class RejectClaimCommand : IRequest
    {
        public Guid ClaimId { get; set; }
    }

}
