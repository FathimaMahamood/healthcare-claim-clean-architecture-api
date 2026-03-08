using HealthcareClaim.Application.Features.Patients.Queries.GetPatientById;
using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Providers.Queries.GetProviderById
{
    
    public class GetProviderByIdQueryHandler:IRequestHandler<GetProviderByIdQuery, ProviderResponse?>
    {
        private readonly IProviderRepository _repository;

        
        public GetProviderByIdQueryHandler(IProviderRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProviderResponse?> Handle(
            GetProviderByIdQuery request,
            CancellationToken cancellationToken)
        {
            var provider = await _repository.GetByIdAsync(request.Id);

            if (provider == null)
                return null;

            return new ProviderResponse
            {
                Id =provider.Id,
                Name =provider.Name,     
                LicenseNumber =provider.LicenseNumber,   
                City = provider.City
            };
        }
    }
}
