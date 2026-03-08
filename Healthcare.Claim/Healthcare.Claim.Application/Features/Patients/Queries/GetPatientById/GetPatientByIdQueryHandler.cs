using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Patients.Queries.GetPatientById
{
    public class GetPatientByIdQueryHandler
    : IRequestHandler<GetPatientByIdQuery, PatientResponse?>
    {
        private readonly IPatientRepository _repository;

        public GetPatientByIdQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatientResponse?> Handle(
            GetPatientByIdQuery request,
            CancellationToken cancellationToken)
        {
            var patient = await _repository.GetByIdAsync(request.Id);

            if (patient == null)
                return null;

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
