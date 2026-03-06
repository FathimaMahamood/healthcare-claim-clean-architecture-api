using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Domain.Entities
{
    public class ClaimAttachment
    {
        public Guid Id { get; private set; }

        public Guid ClaimId { get; private set; }
        public Claim Claim { get; private set; } = default!;

        public string FileName { get; private set; } = default!;
        public string FilePath { get; private set; } = default!;
        public string FileType { get; private set; } = default!;

        public DateTime UploadedAt { get; private set; }

        private ClaimAttachment() { } // EF

        public ClaimAttachment(
            Guid claimId,
            string fileName,
            string filePath,
            string fileType)
        {
            Id = Guid.NewGuid();
            ClaimId = claimId;
            FileName = fileName;
            FilePath = filePath;
            FileType = fileType;
            UploadedAt = DateTime.UtcNow;
        }
    }
}
