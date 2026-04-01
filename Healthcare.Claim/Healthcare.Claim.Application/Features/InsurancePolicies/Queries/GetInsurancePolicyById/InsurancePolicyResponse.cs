using HealthcareClaim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.InsurancePolicies.Queries.GetInsurancePolicyById
{
    public class InsurancePolicyResponse
    {
        public Guid Id { get; set; }

        public string InsuranceCompanyName { get; set; } = default!;

        public string PolicyNumber { get; set; } = default!;

        public InsuranceType InsuranceType { get; set; }

        public decimal CoverageLimit { get; set; }

        public decimal UsedAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpiryDate { get; set; }
    }

}
