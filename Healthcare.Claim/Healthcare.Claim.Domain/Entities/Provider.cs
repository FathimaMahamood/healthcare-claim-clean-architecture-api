using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Domain.Entities
{
    
    public class Provider
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = default!;
        public string LicenseNumber { get; private set; } = default!;
        public string City { get; private set; } = default!;

        public List<Claim> Claims { get; private set; } = new();

        private Provider() { }

        public Provider(string name, string licenseNumber, string city)
        {
            Id = Guid.NewGuid();
            Name = name;
            LicenseNumber = licenseNumber;
            City = city;
        }
    }
}
