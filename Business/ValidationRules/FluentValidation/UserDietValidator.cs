using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserDietValidator: AbstractValidator<UserDiet>
    {
        public UserDietValidator()
        {
            RuleFor(i=>i.UserId).NotNull().NotEmpty();
            RuleFor(i=>i.FoodId).NotNull().NotEmpty();
        }
    }
}
