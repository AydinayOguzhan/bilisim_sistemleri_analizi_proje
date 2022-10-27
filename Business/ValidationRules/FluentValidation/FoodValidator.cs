using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class FoodValidator: AbstractValidator<Food>
    {
        public FoodValidator()
        {
            RuleFor(i=>i.Name).NotEmpty().NotNull().MinimumLength(2);
        }
    }
}
