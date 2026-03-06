using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Domain.Enums
{
    public enum ClaimStatus
    {
        Submitted = 1,
        UnderReview = 2,
        Approved = 3,
        Rejected = 4
    }
}
