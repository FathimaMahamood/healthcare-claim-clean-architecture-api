using HealthcareClaim.Application.Features.Patients.Queries.GetPatientById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Patients.Queries.GetPatientByPatientId
{
    public class GetPatientByPatientIdQuery : IRequest<PatientResponse>
    {
        public string PatientId { get; set; } = default!;
    }
}
