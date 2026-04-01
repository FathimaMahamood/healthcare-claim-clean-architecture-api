using HealthcareClaim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.DTOs
{
    public class CreatePatientRequest
    {
        public string FullName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public NationalityType NationalityType { get; set; }
        public string NationalIdNumber { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string City { get; set; } = default!;
        public string District { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
    }
}
