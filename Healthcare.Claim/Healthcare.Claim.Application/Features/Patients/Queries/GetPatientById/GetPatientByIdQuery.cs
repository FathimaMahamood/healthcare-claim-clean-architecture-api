using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Patients.Queries.GetPatientById
{
    public record GetPatientByIdQuery(Guid Id) : IRequest<PatientResponse>;
}
