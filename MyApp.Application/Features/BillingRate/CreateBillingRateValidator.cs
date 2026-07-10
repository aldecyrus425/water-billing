using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.BillingRate
{
    public class CreateBillingRateValidator : AbstractValidator<CreateBillingRateCommand>
    {
        public CreateBillingRateValidator() 
        {
            RuleFor(x => x.MinimumConsumption).GreaterThan(0).LessThan(x => x.MaximumConsumption).WithMessage("Minimum consumption must be less than maximum").NotEmpty();
            RuleFor(x => x.MaximumConsumption).GreaterThan(x => x.MinimumConsumption).WithMessage("Maximum consumption must be greater than minimum.");
            RuleFor(x => x.PricePerCubicMeter).GreaterThan(0).WithMessage("Price must not below 0.");
            RuleFor(x => x.MinimumCharge).GreaterThan(0).WithMessage("Minimum charge must not below 0");
            RuleFor(x => x.EffectiveDate).NotEmpty();
            RuleFor(x => x.IsActive).NotEmpty();
        }
    }
}
