using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using HealthcareClaim.Application.Features.Claims.Queries.GetPagedClaims;
using HealthcareClaim.Application.Features.Providers.Queries.GetProviderById;
using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Providers.Queries.GetPagedProviders
{
    
    public class GetPagedProvidersQueryHandler
    : IRequestHandler<GetPagedProvidersQuery, PagedResult<ProviderResponse>>
    {
        private readonly IProviderRepository _repository;
        public GetPagedProvidersQueryHandler(IProviderRepository repository)
        {
            _repository = repository;
        }
        

        public async Task<PagedResult<ProviderResponse>> Handle(
            GetPagedProvidersQuery request,
            CancellationToken cancellationToken)
        {
            var (items, totalCount) = await _repository
                .GetPagedAsync(request.PageNumber, request.PageSize);

            var mapped = items.Select(c => new ProviderResponse
            {
                Id = c.Id,
                Name = c.Name,
                LicenseNumber = c.LicenseNumber,
                City = c.City
            }).ToList();

            return new PagedResult<ProviderResponse>
            {
                Items = mapped,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
