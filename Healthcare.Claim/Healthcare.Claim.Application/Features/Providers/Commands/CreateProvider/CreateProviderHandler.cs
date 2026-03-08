using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Providers.Commands.CreateProvider
{
    public class CreateProviderHandler
    : IRequestHandler<CreateProviderCommand, Guid>
    {
        private readonly IProviderRepository _repository;

        public CreateProviderHandler(IProviderRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(
            CreateProviderCommand request,
            CancellationToken cancellationToken)
        {
            var provider = new Provider(
                request.Name,
                request.LicenseNumber,
                request.City);

            await _repository.AddAsync(provider);

            return provider.Id;
        }
    }

}
