using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Domain.Entities;
using HealthcareClaim.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Infrastructure.Repositories
{
    public class ClaimAttachmentRepository : IClaimAttachmentRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaimAttachmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ClaimAttachment attachment)
        {
            await _context.ClaimAttachments.AddAsync(attachment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClaimAttachment>> GetByClaimIdAsync(Guid claimId)
        {
            return await _context.ClaimAttachments
                .Where(a => a.ClaimId == claimId)
                .ToListAsync();
        }
    }

}
