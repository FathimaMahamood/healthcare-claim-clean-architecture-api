using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using HealthcareClaim.Application.Features.Patients.Queries.GetPatientById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Patients.Queries.GetPagedPatient
{

     public record GetPagedPatientQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<PatientResponse>>;


}
