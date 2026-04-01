using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Features.InsurancePolicies.Queries.GetInsurancePolicyById;
using HealthcareClaim.Application.Features.Patients.Queries.GetPagedPatient;
using HealthcareClaim.Application.Features.Patients.Queries.GetPatientById;
using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.InsurancePolicies.Queries.GetPagedInsurancePolicy
{

    public class GetPagedPatientQueryHandler
    : IRequestHandler<GetPagedInsurancePolicyQuery, PagedResult<InsurancePolicyResponse>>
    {
        private readonly IInsurancePolicyRepository _repository;
        public GetPagedPatientQueryHandler(IInsurancePolicyRepository repository)
        {
            _repository = repository;
        }
        public async Task<PagedResult<InsurancePolicyResponse>> Handle(
           GetPagedInsurancePolicyQuery request,
           CancellationToken cancellationToken)
        {
            var (items, totalCount) = await _repository
                .GetPagedAsync(request.PageNumber, request.PageSize);
            var mapped = items.Select(c => new InsurancePolicyResponse
            {
                Id = c.Id,
                PolicyNumber = c.PolicyNumber,
                InsuranceCompanyName = c.InsuranceCompanyName,
                CoverageLimit = c.CoverageLimit,
                StartDate = c.StartDate,
                ExpiryDate = c.ExpiryDate,
                InsuranceType = c.InsuranceType

            }).ToList();
            return new PagedResult<InsurancePolicyResponse>
            {
                Items = mapped,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
