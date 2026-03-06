using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Infrastructure.Persistence;
using HealthcareClaim.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();

            return services;
        }
    }
}
