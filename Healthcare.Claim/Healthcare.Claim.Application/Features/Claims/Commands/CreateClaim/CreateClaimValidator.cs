using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Claims.Commands.CreateClaim
{
    public class CreateClaimValidator
    : AbstractValidator<CreateClaimCommand>
    {
        public CreateClaimValidator()
        {
            RuleFor(x => x.PatientId).NotEmpty();
            RuleFor(x => x.ClaimAmount)
                .GreaterThan(0);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(500);
        }
    }
}
