using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.InsurancePolicies.Queries.GetInsurancePolicyById
{
    public class GetInsurancePolicyByIdQueryHandler
    : IRequestHandler<GetInsurancePolicyByIdQuery, InsurancePolicyResponse>
    {
        private readonly IInsurancePolicyRepository _repository;

        public GetInsurancePolicyByIdQueryHandler(IInsurancePolicyRepository repository)
        {
            _repository = repository;
        }

        public async Task<InsurancePolicyResponse> Handle(
            GetInsurancePolicyByIdQuery request,
            CancellationToken cancellationToken)
        {
            var policy = await _repository.GetByIdAsync(request.Id);

            if (policy == null)
                throw new Exception("Policy not found");

            return new InsurancePolicyResponse
            {
                Id = policy.Id,
                InsuranceCompanyName = policy.InsuranceCompanyName,
                PolicyNumber = policy.PolicyNumber,
                InsuranceType = policy.InsuranceType,
                CoverageLimit = policy.CoverageLimit,
                UsedAmount = policy.UsedAmount,
                StartDate = policy.StartDate,
                ExpiryDate = policy.ExpiryDate
            };
        }
    }

}
