using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class SubscriptionValidator: AbstractValidator<Subscription>
    {
        public SubscriptionValidator()
        {
            RuleFor(i=>i.UserId).NotNull().NotEmpty();
            RuleFor(i=>i.SubscriptionStart).NotNull().NotEmpty();
            RuleFor(i => i.SubscriptionEnd).NotNull().NotEmpty();
        }
    }
}
