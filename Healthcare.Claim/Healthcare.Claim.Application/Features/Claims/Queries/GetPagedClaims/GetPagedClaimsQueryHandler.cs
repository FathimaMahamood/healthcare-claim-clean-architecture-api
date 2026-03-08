using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using HealthcareClaim.Application.Interfaces;
using MediatR;

namespace HealthcareClaim.Application.Features.Claims.Queries.GetPagedClaims
{
    public class GetPagedClaimsQueryHandler
    : IRequestHandler<GetPagedClaimsQuery, PagedResult<ClaimResponse>>
    {
        private readonly IClaimRepository _repository;

        public GetPagedClaimsQueryHandler(IClaimRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<ClaimResponse>> Handle(
            GetPagedClaimsQuery request,
            CancellationToken cancellationToken)
        {
            var (items, totalCount) = await _repository
                .GetPagedAsync(request.PageNumber, request.PageSize);

            var mapped = items.Select(c => new ClaimResponse
            {
                Id = c.Id,
                PatientId = c.PatientId,
                ClaimAmount = c.ClaimAmount,
                Status = c.Status,
                CreatedAt = c.CreatedAt
            }).ToList();

            return new PagedResult<ClaimResponse>
            {
                Items = mapped,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}
