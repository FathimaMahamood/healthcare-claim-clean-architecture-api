using HealthcareClaim.Application.Common;
using HealthcareClaim.Application.Features.Claims.Queries.GetClaimById;
using HealthcareClaim.Application.Features.Claims.Queries.GetPagedClaims;
using HealthcareClaim.Application.Features.Patients.Queries.GetPatientById;
using HealthcareClaim.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Patients.Queries.GetPagedlPatient
{
    
    public class GetPagedPatientQueryHandler
    : IRequestHandler<GetPagedPatientQuery, PagedResult<PatientResponse>>
    {
        private readonly IPatientRepository _repository;

        public GetPagedPatientQueryHandler(IPatientRepository repository)
        {
            _repository = repository;
        }
        public async Task<PagedResult<PatientResponse>> Handle(
           GetPagedPatientQuery request,
           CancellationToken cancellationToken)
        {
            var (items, totalCount) = await _repository
                .GetPagedAsync(request.PageNumber, request.PageSize);

            var mapped = items.Select(c => new PatientResponse
            {
                Id = c.Id,
               FullName= c.FullName,
               City=c.City,
               DateOfBirth=c.DateOfBirth,
               Email=c.Email,
               District=c.District,
               InsurancePolicyId=c.InsurancePolicyId,
               NationalIdNumber=c.NationalIdNumber,
               NationalityType=c.NationalityType,
                PatientNumber = c.PatientNumber,
               PhoneNumber=c.PhoneNumber,
               PostalCode = c.PostalCode
            }).ToList();

            return new PagedResult<PatientResponse>
            {
                Items = mapped,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

        }
    }
}
