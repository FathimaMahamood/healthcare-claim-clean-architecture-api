using HealthcareClaim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Interfaces
{
    public interface IPatientRepository
    {
        Task AddAsync(Patient patient);
        Task<Patient?> GetByIdAsync(Guid id); 
        Task<Patient?> GetByIdWithInsuranceAsync(Guid id);

        Task<List<Patient>> GetPagedAsync(int pageNumber, int pageSize);
        Task<int> CountAsync();
        Task SaveChangesAsync();
    }
}
