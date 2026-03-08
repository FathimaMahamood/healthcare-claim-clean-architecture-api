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
        private readonly IPatientRepository _patientRepository; private readonly IProviderRepository _providerRepository;


        public CreateClaimCommandHandler( IClaimRepository claimRepository, IPatientRepository patientRepository, IProviderRepository providerRepository)
        {
            _claimRepository = claimRepository;
            _patientRepository = patientRepository;
            _providerRepository = providerRepository;
        }

        public async Task<Guid> Handle( CreateClaimCommand request, CancellationToken cancellationToken)
        {

            
            var patient = await _patientRepository
                .GetByIdAsync(request.PatientId);

            if (patient == null)
                throw new Exception("Patient not found");

            //// 2️⃣ Check insurance
            //if (patient.InsurancePolicy == null)
            //    throw new Exception("Patient has no insurance policy");

            //// 3️⃣ Check insurance limit
            //if (patient.InsurancePolicy.RemainingLimit < request.ClaimAmount)
            //    throw new Exception("Insurance limit exceeded");

            var provider = await _providerRepository.GetByIdAsync(request.ProviderId);

            if (provider == null)
                throw new Exception("Provider not found");
            // 4️⃣ Create claim
            var claim = new Claim( request.PatientId, request.ProviderId,  request.ClaimAmount,  request.Description );

            //patient.InsurancePolicy.UseAmount(request.ClaimAmount);


            await _claimRepository.AddAsync(claim);

            await _claimRepository.SaveChangesAsync();

            return claim.Id;
        }
    }
}
