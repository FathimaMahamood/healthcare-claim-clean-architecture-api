using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Domain.Entities;
using HealthcareClaim.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Commands.RejectClaim
{
    public class RejectClaimCommandHandler
    : IRequestHandler<RejectClaimCommand>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IPatientRepository _patientRepository;

        public RejectClaimCommandHandler(
            IClaimRepository claimRepository,
            IPatientRepository patientRepository)
        {
            _claimRepository = claimRepository;
            _patientRepository = patientRepository;
        }

        public async Task Handle(
            RejectClaimCommand request,
            CancellationToken cancellationToken)
        {
            var claim = await _claimRepository
                .GetByIdAsync(request.ClaimId);

            if (claim == null)
                throw new Exception("Claim not found.");

            // If claim was approved, we need insurance policy to revert
            InsurancePolicy? policy = null;

            if (claim.Status == ClaimStatus.Approved)
            {
                var patient = await _patientRepository
                    .GetByIdWithInsuranceAsync(claim.PatientId);

                if (patient == null)
                    throw new Exception("Patient not found.");

                if (patient.InsurancePolicy == null)
                    throw new Exception("Insurance policy not found.");

                policy = patient.InsurancePolicy;
            }

            claim.Reject(policy);

            await _claimRepository.SaveChangesAsync();
        }
    }

}
