using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.MeterReading.Create
{
    public class CreateMeterReadingValidator : AbstractValidator<CreateMeterReadingCommand>
    {
        public CreateMeterReadingValidator() 
        {
            RuleFor(x => x.WaterMeterSerialNumber).NotEmpty();
            RuleFor(x => x.BillingMonth).NotEmpty();
            RuleFor(x => x.CurrentReading).NotEmpty();
            RuleFor(x => x.ReadingDate).Equal(DateTime.Now).NotEmpty();
            RuleFor(x => x.ReaderId).GreaterThan(0).NotEmpty();
        }
    }
}
