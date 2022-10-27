using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(i => i.FirstName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(i=>i.LastName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(i=>i.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(i=>i.PhoneNumber).NotNull().NotEmpty().Length(11);
        }
    }
}
