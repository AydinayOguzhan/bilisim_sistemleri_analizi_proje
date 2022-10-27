using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class WorkoutPlanValidator: AbstractValidator<WorkoutPlan>
    {
        public WorkoutPlanValidator()
        {
            RuleFor(i => i.Name).NotNull().NotEmpty().MinimumLength(1);
        }
    }
}
