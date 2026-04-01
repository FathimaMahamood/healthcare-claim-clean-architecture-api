using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetClaimAttachmentsQuery
{
    public class GetClaimAttachmentsQuery : IRequest<List<ClaimAttachmentResponse>>
    {
        public Guid ClaimId { get; set; }
    }

}
