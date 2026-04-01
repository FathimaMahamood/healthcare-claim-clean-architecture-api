using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Commands.UploadClaimAttachment
{
    public class UploadClaimAttachmentCommand : IRequest<Unit>
    {
        public Guid ClaimId { get; set; }

        public IFormFile File { get; set; } = default!;
    }

}
