using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Payment.Create
{
    public class CreatePaymentValidator : AbstractValidator<CreatePaymentCommands>
    {
        public CreatePaymentValidator()
        {
            RuleFor(x => x.BillId).GreaterThan(0);
            RuleFor(x => x.ORNumber).NotEmpty();
            RuleFor(x => x.PaymentDate).NotEmpty();
            RuleFor(x => x.AmountPaid).GreaterThan(0).NotEmpty();
            RuleFor(x => x.AmountTendered).GreaterThan(0).NotEmpty();
            RuleFor(x => x.PaymentMethod).NotEmpty();
            RuleFor(x => x.ReceivedBy).GreaterThan(0).NotEmpty();
        }
    }
}
