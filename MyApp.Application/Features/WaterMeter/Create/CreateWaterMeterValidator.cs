using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.WaterMeter.Create
{
    public class CreateWaterMeterValidator : AbstractValidator<CreateWaterMeterCommand>
    {
        public CreateWaterMeterValidator() 
        {
            RuleFor(x => x.CustomerId).GreaterThan(0).NotEmpty();
            RuleFor(x => x.MeterSerialNumber).NotEmpty();
            RuleFor(x => x.MeterBrand).NotEmpty();
            RuleFor(x => x.MeterSize).NotEmpty();
            RuleFor(x => x.InstallationDate).NotEmpty();
            RuleFor(x => x.MeterStatus).NotEmpty();
            RuleFor(x => x.InitialReading).GreaterThan(0).NotEmpty();
            RuleFor(x => x.CurrentReading).NotEmpty();
        }
    }
}
