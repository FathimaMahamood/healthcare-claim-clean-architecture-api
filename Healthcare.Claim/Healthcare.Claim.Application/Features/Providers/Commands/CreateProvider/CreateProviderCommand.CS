using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Providers.Commands.CreateProvider
{
    public record CreateProviderCommand(string Name,string LicenseNumber,string City) : IRequest<Guid>;

}
