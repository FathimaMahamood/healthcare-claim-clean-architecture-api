using HealthcareClaim.Application.Interfaces;
using HealthcareClaim.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareClaim.Application.Features.Patients.Commands.CreatePatient
{
    public class CreatePatientCommandHandler
    : IRequestHandler<CreatePatientCommand, Guid>
    {
        private readonly IPatientRepository _repository;

        public CreatePatientCommandHandler(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(
            CreatePatientCommand request,
            CancellationToken cancellationToken)
        {
            var patient = new Patient(
                request.FullName,
                request.DateOfBirth,
                request.NationalityType,
                request.GenderType,
                request.NationalIdNumber,
                request.PhoneNumber,
                request.City,
                request.District,
                request.PostalCode);

            await _repository.AddAsync(patient);
            await _repository.SaveChangesAsync();

            return patient.Id;
        }
    }
}
