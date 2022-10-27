using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserMoveValidator: AbstractValidator<UserMove>
    {
        public UserMoveValidator()
        {
            RuleFor(i=>i.UserId).NotNull().NotEmpty();
            RuleFor(i => i.MoveId).NotNull().NotEmpty();
            RuleFor(i => i.DayId).NotNull().NotEmpty();
        }
    }
}
