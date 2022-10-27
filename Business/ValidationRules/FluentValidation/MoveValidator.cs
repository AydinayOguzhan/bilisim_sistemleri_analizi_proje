using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MoveValidator: AbstractValidator<Move>
    {
        public MoveValidator()
        {
            RuleFor(i=>i.Name).NotEmpty().NotNull().MinimumLength(1);
        }
    }
}
