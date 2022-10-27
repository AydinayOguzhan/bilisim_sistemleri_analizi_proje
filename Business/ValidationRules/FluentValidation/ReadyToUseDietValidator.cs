using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ReadyToUseDietValidator: AbstractValidator<ReadyToUseDiet>
    {
        public ReadyToUseDietValidator()
        {
            RuleFor(i=>i.Name).NotEmpty().NotNull().MinimumLength(1);
        }
    }
}
