using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Commands.UploadClaimAttachment
{
    public class UploadClaimAttachmentHandler
    : IRequestHandler<UploadClaimAttachmentCommand, Unit>
    {
        private readonly IClaimAttachmentRepository _repository;
        private readonly IFileStorageService _fileService;
        private readonly IClaimRepository _claimRepository;

        public UploadClaimAttachmentHandler(IClaimAttachmentRepository repository, IFileStorageService fileService, IClaimRepository claimRepository)
        {
            _repository = repository;
            _fileService = fileService;
            _claimRepository = claimRepository;
        }

        public async Task<Unit> Handle( UploadClaimAttachmentCommand request,CancellationToken cancellationToken)
        {
            var claim = await _claimRepository.GetByIdAsync(request.ClaimId);

            if (claim == null)
                throw new Exception("Claim not found");

            var filePath = await _fileService.SaveFileAsync(request.File);

            var attachment = new ClaimAttachment(
                request.ClaimId,
                request.File.FileName,
                filePath,
                request.File.ContentType
            );

            await _repository.AddAsync(attachment);

            return Unit.Value;
        }
    }
}
