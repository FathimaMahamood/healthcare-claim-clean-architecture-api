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
    public class ProviderRepository : IProviderRepository
    {
        private readonly ApplicationDbContext _context;

        public ProviderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Provider?> GetByIdAsync(Guid id)
        {
            return await _context.Providers
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Provider>> GetAllAsync()
        {
            return await _context.Providers.ToListAsync();
        }

        public async Task AddAsync(Provider provider)
        {
            await _context.Providers.AddAsync(provider);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
