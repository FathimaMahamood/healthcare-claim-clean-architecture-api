using HealthcareClaim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Interfaces
{
    public interface IInsurancePolicyRepository
    {
        Task AddAsync(InsurancePolicy policy);
        Task<InsurancePolicy?> GetByIdAsync(Guid id);
        Task<(List<InsurancePolicy> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);

    }
}
