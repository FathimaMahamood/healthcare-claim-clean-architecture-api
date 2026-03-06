using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareClaim.Domain.Entities;



namespace HealthcareClaim.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Claim> Claims => Set<Claim>(); 
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<InsurancePolicy> InsurancePolicies => Set<InsurancePolicy>();
        public DbSet<ClaimAttachment> ClaimAttachments => Set<ClaimAttachment>();
        public DbSet<Provider> Providers => Set<Provider>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.ClaimAmount)
                      .HasPrecision(18, 2);

                entity.Property(c => c.Status)
                      .HasConversion<string>();
            });
            modelBuilder.Entity<Patient>()
                .Property(p => p.PatientNumber)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Patient>()
                .Ignore(p => p.PatientId);
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Claims)
                .WithOne(c => c.Patient)
                .HasForeignKey(c => c.PatientId);
            modelBuilder.Entity<Patient>()
                .HasOne(p => p.InsurancePolicy)
                .WithMany()
                .HasForeignKey(p => p.InsurancePolicyId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<InsurancePolicy>()
                .Property(i => i.CoverageLimit)
                .HasPrecision(18, 2);

            modelBuilder.Entity<InsurancePolicy>()
                .Property(i => i.UsedAmount)
                .HasPrecision(18, 2);

        }
    }
}
