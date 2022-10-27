using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class WorkoutPlanMoveValidator: AbstractValidator<WorkoutPlanMove>
    {
        public WorkoutPlanMoveValidator()
        {
            RuleFor(i=>i.MoveId).NotNull().NotEmpty();
            RuleFor(i => i.WorkoutPlanId).NotNull().NotEmpty();
            RuleFor(i => i.DayId).NotNull().NotEmpty();
        }
    }
}
