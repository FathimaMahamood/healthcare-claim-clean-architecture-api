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

        Task<(List<Patient> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize);
        Task<Patient?> GetByPatientIdAsync(string PatientId);

        Task<int> CountAsync();
        Task SaveChangesAsync();
    }
}
