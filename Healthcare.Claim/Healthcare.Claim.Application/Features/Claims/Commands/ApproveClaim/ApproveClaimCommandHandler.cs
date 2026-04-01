using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Commands.ApproveClaim
{
    public class ApproveClaimCommandHandler
    : IRequestHandler<ApproveClaimCommand>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IPatientRepository _patientRepository;

        public ApproveClaimCommandHandler(
            IClaimRepository claimRepository,
            IPatientRepository patientRepository)
        {
            _claimRepository = claimRepository;
            _patientRepository = patientRepository;
        }

        public async Task Handle(
            ApproveClaimCommand request,
            CancellationToken cancellationToken)
        {
            var claim = await _claimRepository.GetByIdAsync(request.ClaimId);


            if (claim == null)
                throw new Exception("Claim not found.");

            var patient = await _patientRepository
                .GetByIdWithInsuranceAsync(claim.PatientId);

            if (patient == null)
                throw new Exception("Patient not found.");

            if (patient.InsurancePolicy == null)
                throw new Exception("Patient does not have insurance");

            var policy = patient.InsurancePolicy;

            //  Policy must be active
            if (!policy.IsActive)
                throw new Exception("Insurance policy is expired");

            //  Check coverage
            var remainingCoverage = policy.CoverageLimit - policy.UsedAmount;

            if (claim.ClaimAmount > remainingCoverage)
                throw new Exception("Insufficient insurance coverage");

            // Deduct coverage
            policy.UseAmount(claim.ClaimAmount);

            //  Approve claim
            claim.Approve();

            await _claimRepository.SaveChangesAsync();

            //return Unit.Value;
        }
    }
}
