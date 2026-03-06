using HealthcareClaim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Domain.Entities
{
    public class InsurancePolicy
    {
        public Guid Id { get; private set; }

        public string InsuranceCompanyName { get; private set; } = default!;
        public string PolicyNumber { get; private set; } = default!;

        public InsuranceType InsuranceType { get; private set; }

        public decimal CoverageLimit { get; private set; }
        public decimal UsedAmount { get; private set; }

        public decimal RemainingLimit => CoverageLimit - UsedAmount;

        public DateTime StartDate { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        public bool IsSuspended { get; private set; }

        public bool IsActive =>
            DateTime.UtcNow >= StartDate &&
            DateTime.UtcNow <= ExpiryDate &&
            !IsSuspended;

        private InsurancePolicy() { } // EF

        public InsurancePolicy(
            string insuranceCompanyName,
            string policyNumber,
            InsuranceType insuranceType,
            decimal coverageLimit,
            DateTime startDate,
            DateTime expiryDate)
        {
            Id = Guid.NewGuid();
            InsuranceCompanyName = insuranceCompanyName;
            PolicyNumber = policyNumber;
            InsuranceType = insuranceType;
            CoverageLimit = coverageLimit;
            UsedAmount = 0;
            StartDate = startDate;
            ExpiryDate = expiryDate;
            IsSuspended = false;
        }

        public void ValidateCoverage(decimal amount)
        {
            if (!IsActive)
                throw new InvalidOperationException("Insurance policy is not active.");

            if (amount > RemainingLimit)
                throw new InvalidOperationException("Insurance limit exceeded.");
        }

        public void UseAmount(decimal amount)
        {
            ValidateCoverage(amount);
            UsedAmount += amount;
        }

        public void RevertAmount(decimal amount)
        {
            if (amount > UsedAmount)
                throw new InvalidOperationException("Invalid revert amount.");

            UsedAmount -= amount;
        }

        public void Suspend() => IsSuspended = true;
        public void Activate() => IsSuspended = false;
    }


}
