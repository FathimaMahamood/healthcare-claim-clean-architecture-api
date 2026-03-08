using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetClaimsByPatientId
{
    public class GetClaimsByPatientIdQueryHandler
    : IRequestHandler<GetClaimsByPatientIdQuery, List<ClaimResponse>>
    {
        private readonly IClaimRepository _repository;

        public GetClaimsByPatientIdQueryHandler(IClaimRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ClaimResponse>> Handle(
            GetClaimsByPatientIdQuery request,
            CancellationToken cancellationToken)
        {
            var claims = await _repository.GetByPatientIdAsync(request.PatientId);

            return claims.Select(c => new ClaimResponse
            {
                Id = c.Id,
                PatientId = c.PatientId,
                ClaimAmount = c.ClaimAmount,
                Status = c.Status,
                CreatedAt = c.CreatedAt
            }).ToList();
        }
    }
}
