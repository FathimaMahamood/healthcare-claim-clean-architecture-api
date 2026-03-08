using HealthcareClaim.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetClaimById
{
    public class ClaimResponse
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public decimal ClaimAmount { get; set; }
        public ClaimStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
