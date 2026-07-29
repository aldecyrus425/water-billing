using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.Authenticate
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
