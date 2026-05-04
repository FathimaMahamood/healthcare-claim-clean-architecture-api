using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Common
{
    public class RiskResponse
    {
        public int RiskScore { get; set; }
        public string RiskLevel { get; set; } = default!;
    }

}
