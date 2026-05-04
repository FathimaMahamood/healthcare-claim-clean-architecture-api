using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimCommandHandler
    : IRequestHandler<CreateClaimCommand, Guid>
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IPatientRepository _patientRepository; 
        private readonly IProviderRepository _providerRepository;
        private readonly IAiRiskService _aiService;



        public CreateClaimCommandHandler( IClaimRepository claimRepository, IPatientRepository patientRepository, IProviderRepository providerRepository, IAiRiskService aiService)
        {
            _claimRepository = claimRepository;
            _patientRepository = patientRepository;
            _providerRepository = providerRepository;
            _aiService = aiService;
        }

        public async Task<Guid> Handle( CreateClaimCommand request, CancellationToken cancellationToken)
        {

            
            var patient = await _patientRepository
                .GetByIdAsync(request.PatientId);

            if (patient == null)
                throw new Exception("Patient not found");
            var today = DateTime.UtcNow;
            var age = today.Year - patient.DateOfBirth.Year;

            if (patient.DateOfBirth.Date > today.AddYears(-age))
                age--;

            var riskResponse = await _aiService.AnalyzeAsync(new RiskRequest
            {
                ClaimAmount = request.ClaimAmount,
                PatientAge = age,
                HasInsurance = patient.InsurancePolicy != null
            });
            if (riskResponse == null)
                throw new Exception("AI service failed");
            // Check insurance
            //if (patient.InsurancePolicy == null)
            //    throw new Exception("Patient has no insurance policy");

            //Check insurance limit
            //if (patient.InsurancePolicy.RemainingLimit < request.ClaimAmount)
            //    throw new Exception("Insurance limit exceeded");

            var provider = await _providerRepository.GetByIdAsync(request.ProviderId);

            if (provider == null)
                throw new Exception("Provider not found");
            //  Create claim
            var claim = new Claim( request.PatientId, request.ProviderId,  request.ClaimAmount,  request.Description );
            
            claim.SetRisk(riskResponse.RiskScore, riskResponse.RiskLevel);

            //patient.InsurancePolicy.UseAmount(request.ClaimAmount);


            await _claimRepository.AddAsync(claim);

            await _claimRepository.SaveChangesAsync();

            return claim.Id;
        }
    }
}
