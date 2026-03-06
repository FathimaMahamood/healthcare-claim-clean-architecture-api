using HealthcareClaim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Domain.Entities
{
    public class Claim
    {
        public Claim(Guid patientId, Guid providerId, decimal claimAmount, string description)
        {
            Id = Guid.NewGuid();
            PatientId = patientId;
            ClaimAmount = claimAmount;
            ProviderId = providerId;
            Status = ClaimStatus.Submitted;
            CreatedAt = DateTime.UtcNow;
            Description = description;
        }
        public Guid Id { get; private set; }

        public Guid PatientId { get; private set; }
        public Patient Patient { get; private set; } = default!;

        public decimal ClaimAmount { get; private set; }
        public ClaimStatus Status { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public string Description { get; private set; } = default!;
        public List<ClaimAttachment> Attachments { get; private set; } = new ();
        public Guid ProviderId { get; private set; }
        public Provider Provider { get; private set; } = default!;

        public void Approve()
        {
            if (Patient?.InsurancePolicy == null)
                throw new InvalidOperationException("Patient has no insurance.");

            if (Patient.InsurancePolicy.UsedAmount + ClaimAmount >
                Patient.InsurancePolicy.CoverageLimit)
            {
                throw new InvalidOperationException("Insurance limit exceeded.");
            }

            if (Status != ClaimStatus.Submitted)
                throw new InvalidOperationException("Only submitted claims can be approved.");

            Status = ClaimStatus.Approved;
        }
        public void Approve(InsurancePolicy policy)
        {
            if (Status != ClaimStatus.Submitted)
                throw new InvalidOperationException("Only submitted claims can be approved.");

            policy.UseAmount(ClaimAmount);

            Status = ClaimStatus.Approved;
        }
        public void Reject()
        {
            if (Status != ClaimStatus.Submitted)
                throw new InvalidOperationException("Only submitted claims can be rejected.");

            Status = ClaimStatus.Rejected;
        }
        public void Reject(InsurancePolicy? policy = null)
        {
            if (Status == ClaimStatus.Rejected)
                throw new InvalidOperationException("Claim is already rejected.");

            if (Status == ClaimStatus.Approved)
            {
                if (policy == null)
                    throw new InvalidOperationException("Insurance policy required to revert approved claim.");

                policy.RevertAmount(ClaimAmount);
            }

            Status = ClaimStatus.Rejected;
        }

    }

}
