using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Providers.Queries.GetProviderById
{
    public class ProviderResponse
    {
        public Guid Id { get;  set; }

        public string Name { get;  set; } = default!;
        public string LicenseNumber { get;  set; } = default!;
        public string City { get;  set; } = default!;

    }
}
