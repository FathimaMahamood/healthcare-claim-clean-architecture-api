using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Common
{
    public class RiskRequest
    {
        [JsonPropertyName("claimAmount")]
        public decimal ClaimAmount { get; set; }

        [JsonPropertyName("patientAge")]
        public int PatientAge { get; set; }

        [JsonPropertyName("hasInsurance")]
        public bool HasInsurance { get; set; }
    }

}
