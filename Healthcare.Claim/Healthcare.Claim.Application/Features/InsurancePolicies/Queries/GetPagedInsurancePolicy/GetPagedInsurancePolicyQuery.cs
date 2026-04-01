using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Features.InsurancePolicies.Queries.GetInsurancePolicyById;
using HealthcareClaim.Application.Features.Patients.Queries.GetPatientById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.InsurancePolicies.Queries.GetPagedInsurancePolicy
{
    public record GetPagedInsurancePolicyQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<InsurancePolicyResponse>>;

}
