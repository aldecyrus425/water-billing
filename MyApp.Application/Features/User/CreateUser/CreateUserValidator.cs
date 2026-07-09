using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Features.User.CreateUser
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.PasswordHash).NotEmpty();
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.RoleId).GreaterThan(0);
            RuleFor(x => x.IsActive).NotEmpty();
        }
    }
}
