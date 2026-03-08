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
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }
        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            return await _context.Patients
                .Include(p => p.InsurancePolicy)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        
        public async Task<(List<Patient> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _context.Patients.AsQueryable();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(c => c.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
        public async Task<int> CountAsync()
        {
            return await _context.Patients.CountAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Patient?> GetByIdWithInsuranceAsync(Guid id)
        {
            return await _context.Patients.Include(p => p.InsurancePolicy).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Patient?> GetByPatientIdAsync(string PatientId)
        {
            int patientNumber = int.Parse(PatientId.Substring(2));

            return await _context.Patients
                .FirstOrDefaultAsync(p => p.PatientNumber == patientNumber);
        }
    }
}
