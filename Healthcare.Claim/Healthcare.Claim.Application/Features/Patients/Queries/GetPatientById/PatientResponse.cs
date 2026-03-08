using HealthcareClaim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Patients.Queries.GetPatientById
{
    public class PatientResponse
    {
        public Guid Id { get; set; }
        public int PatientNumber { get;  set; }

        public string PatientId => $"P-{PatientNumber:D6}";
        public string FullName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }

        public NationalityType NationalityType { get; set; }
        public string NationalIdNumber { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;
        public string? Email { get; set; }

        public string City { get; set; } = default!;
        public string District { get; set; } = default!;
        public string PostalCode { get; set; } = default!;

        public Guid? InsurancePolicyId { get; set; }
    }
}
