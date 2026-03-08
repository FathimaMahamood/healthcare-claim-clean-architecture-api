using HealthcareClaim.Application.Features.Patients.Queries.GetPatientById;
using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Patients.Queries.GetPatientByPatientId
{

    public class GetPatientByPatientIdQueryHandler
        : IRequestHandler<GetPatientByPatientIdQuery, PatientResponse>
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByPatientIdQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientResponse> Handle(
            GetPatientByPatientIdQuery request,
            CancellationToken cancellationToken)
        {
            var patient = await _patientRepository
                .GetByPatientIdAsync(request.PatientId);

            if (patient == null)
                throw new Exception("Patient not found.");

            return new PatientResponse
            {
                Id = patient.Id,
                PatientNumber = patient.PatientNumber,
                FullName = patient.FullName,
                DateOfBirth = patient.DateOfBirth,
                NationalityType = patient.NationalityType,
                NationalIdNumber = patient.NationalIdNumber,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                City = patient.City,
                District = patient.District,
                PostalCode = patient.PostalCode,
                InsurancePolicyId = patient.InsurancePolicyId
            };
        }
    }

}
