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
    public class InsurancePolicyRepository : IInsurancePolicyRepository
    {
        private readonly ApplicationDbContext _context;

        public InsurancePolicyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(InsurancePolicy policy)
        {
            await _context.InsurancePolicies.AddAsync(policy);
            await _context.SaveChangesAsync();
        }

        public async Task<InsurancePolicy?> GetByIdAsync(Guid id)
        {
            return await _context.InsurancePolicies.FindAsync(id);
        }

        public async Task<(List<InsurancePolicy> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.InsurancePolicies.AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }

}
