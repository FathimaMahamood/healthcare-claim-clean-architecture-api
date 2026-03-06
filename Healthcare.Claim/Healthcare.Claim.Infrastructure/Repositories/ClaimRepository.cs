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
    public class ClaimRepository : IClaimRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaimRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Claim claim)
        {
            await _context.Claims.AddAsync(claim);
        }

        public async Task<Claim?> GetByIdAsync(Guid id)
        {
            return await _context.Claims.FindAsync(id);
        }

        public async Task<(List<Claim> Items, int TotalCount)>GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Claims.AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<List<Claim>> GetByPatientIdAsync(Guid patientId)
        {
            return await _context.Claims
                .Where(c => c.PatientId == patientId)
                .ToListAsync();
        }
    }
}
