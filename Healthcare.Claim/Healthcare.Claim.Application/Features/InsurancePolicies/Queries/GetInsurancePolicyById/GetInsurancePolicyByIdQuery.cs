using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.InsurancePolicies.Queries.GetInsurancePolicyById
{
    public class GetInsurancePolicyByIdQuery : IRequest<InsurancePolicyResponse>
    {
        public Guid Id { get; set; }
    }

}
