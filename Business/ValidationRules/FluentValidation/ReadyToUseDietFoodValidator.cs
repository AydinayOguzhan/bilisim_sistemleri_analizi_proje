using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ReadyToUseDietFoodValidator: AbstractValidator<ReadyToUseDietFood>
    {
        public ReadyToUseDietFoodValidator()
        {
            RuleFor(i=>i.FoodId).NotNull().NotEmpty();
            RuleFor(i => i.ReadyToUseDietId).NotNull().NotEmpty();
        }
    }
}
