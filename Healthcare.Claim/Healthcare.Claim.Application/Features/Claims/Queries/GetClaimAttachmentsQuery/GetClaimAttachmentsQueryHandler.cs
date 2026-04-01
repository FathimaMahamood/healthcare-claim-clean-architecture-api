using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetClaimAttachmentsQuery
{
    public class GetClaimAttachmentsQueryHandler
    : IRequestHandler<GetClaimAttachmentsQuery, List<ClaimAttachmentResponse>>
    {
        private readonly IClaimAttachmentRepository _repository;

        public GetClaimAttachmentsQueryHandler(
            IClaimAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClaimAttachmentResponse>> Handle(
            GetClaimAttachmentsQuery request,
            CancellationToken cancellationToken)
        {
            var attachments = await _repository
                .GetByClaimIdAsync(request.ClaimId);

            return attachments.Select(a => new ClaimAttachmentResponse
            {
                Id = a.Id,
                FileName = a.FileName,
                FileUrl = "/" + a.FilePath, // important
                FileType = a.FileType,
                UploadedAt = a.UploadedAt
            }).ToList();
        }
    }

}
