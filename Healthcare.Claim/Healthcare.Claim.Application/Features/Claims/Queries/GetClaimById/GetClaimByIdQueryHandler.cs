using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetClaimById
{
    public class GetClaimByIdQueryHandler
    : IRequestHandler<GetClaimByIdQuery, ClaimResponse?>
    {
        private readonly IClaimRepository _repository;

        public GetClaimByIdQueryHandler(IClaimRepository repository)
        {
            _repository = repository;
        }

        public async Task<ClaimResponse?> Handle(
            GetClaimByIdQuery request,
            CancellationToken cancellationToken)
        {
            var claim = await _repository.GetByIdAsync(request.Id);

            if (claim == null)
                return null;

            return new ClaimResponse
            {
                Id = claim.Id,
                PatientId = claim.PatientId,
                ClaimAmount = claim.ClaimAmount,
                Status = claim.Status,
                CreatedAt = claim.CreatedAt
            };
        }
    }
}
