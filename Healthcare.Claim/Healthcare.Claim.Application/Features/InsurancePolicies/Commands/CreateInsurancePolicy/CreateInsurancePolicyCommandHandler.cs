using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.InsurancePolicies.Commands.CreateInsurancePolicy
{
    public class CreateInsurancePolicyCommandHandler
    : IRequestHandler<CreateInsurancePolicyCommand, Guid>
    {
        private readonly IInsurancePolicyRepository _policyRepository;
        private readonly IPatientRepository _patientRepository;

        public CreateInsurancePolicyCommandHandler(
            IInsurancePolicyRepository policyRepository,
            IPatientRepository patientRepository)
        {
            _policyRepository = policyRepository;
            _patientRepository = patientRepository;
        }

        public async Task<Guid> Handle(
            CreateInsurancePolicyCommand request,
            CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetByIdAsync(request.PatientId);

            if (patient == null)
                throw new Exception("Patient not found");

            var policy = new InsurancePolicy(
                request.InsuranceCompanyName,
                request.PolicyNumber,
                request.InsuranceType,
                request.CoverageLimit,
                request.StartDate,
                request.ExpiryDate
            );

            patient.AssignInsurance(policy);

            await _policyRepository.AddAsync(policy);

            return policy.Id;
        }
    }
}
