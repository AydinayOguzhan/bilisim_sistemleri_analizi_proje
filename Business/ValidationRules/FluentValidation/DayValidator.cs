using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class DayValidator: AbstractValidator<Day>
    {
        public DayValidator()
        {
            RuleFor(i=>i.Name).NotEmpty().NotNull().MinimumLength(4);
        }
    }
}
