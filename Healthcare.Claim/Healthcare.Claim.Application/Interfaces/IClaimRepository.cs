using HealthcareClaim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Interfaces
{
    public interface IClaimRepository
    {
        Task AddAsync(Claim claim);
        Task<Claim?> GetByIdAsync(Guid id);
        Task<(List<Claim> Items, int TotalCount)>GetPagedAsync(int pageNumber, int pageSize); 
        Task SaveChangesAsync();
        Task<List<Claim>> GetByPatientIdAsync(Guid patientId);
    }
}
