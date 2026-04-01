using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetClaimAttachmentsQuery
{
    public class ClaimAttachmentResponse
    {
        public Guid Id { get; set; }

        public string FileName { get; set; } = default!;

        public string FileUrl { get; set; } = default!;

        public string FileType { get; set; } = default!;

        public DateTime UploadedAt { get; set; }
    }

}
