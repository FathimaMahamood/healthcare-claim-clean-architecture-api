using HealthcareClaim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Interfaces
{
    public interface IProviderRepository
    {
        Task<Provider?> GetByIdAsync(Guid id);
        Task AddAsync(Provider provider);

        Task<(List<Provider> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
        
        Task SaveChangesAsync();
    }
}
