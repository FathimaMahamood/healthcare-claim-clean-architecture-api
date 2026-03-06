using HealthcareClaim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Domain.Entities
{
    

    
    public class Patient
    {
        public Guid Id { get; private set; }

        public int PatientNumber { get; private set; }

        public string PatientId => $"P-{PatientNumber:D6}";
        public string FullName { get; private set; } = default!;
        public DateTime DateOfBirth { get; private set; }

        public NationalityType NationalityType { get; private set; }
        public string NationalIdNumber { get; private set; } = default!;

        public string PhoneNumber { get; private set; } = default!;
        public string? Email { get; private set; }

        public string City { get; private set; } = default!;
        public string District { get; private set; } = default!;
        public string PostalCode { get; private set; } = default!;

        public Guid? InsurancePolicyId { get; private set; }
        public InsurancePolicy? InsurancePolicy { get; private set; }

        public List<Claim> Claims { get; private set; } = new();

        private Patient() { } // EF

        public Patient(
            int patientId,
            string fullName,
            DateTime dateOfBirth,
            NationalityType nationalityType,
            string nationalIdNumber,
            string phoneNumber,
            string city,
            string district,
            string postalCode)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            NationalityType = nationalityType;
            NationalIdNumber = nationalIdNumber;
            PhoneNumber = phoneNumber;
            City = city;
            District = district;
            PostalCode = postalCode;
        }

        public void AssignInsurance(InsurancePolicy policy)
        {
            InsurancePolicy = policy;
            InsurancePolicyId = policy.Id;
        }
    }


}
