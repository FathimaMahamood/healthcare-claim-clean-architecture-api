using HealthcareClaim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Interfaces
{
    public interface IClaimAttachmentRepository
    {
        Task AddAsync(ClaimAttachment attachment);
        Task<List<ClaimAttachment>> GetByClaimIdAsync(Guid claimId);
    }
}
