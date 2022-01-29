using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Validations
{
    public class DealValidator: AbstractValidator<Deal>
    {
        public DealValidator()
        {
            RuleFor(x => x.ItemId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage($"Mandatory Field: {nameof(Deal.NumberOfItems)}");

            RuleFor(x => x.NumberOfItems)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage($"Mandatory Field: {nameof(Deal.NumberOfItems)}");

            RuleFor(x => x.IsActive)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage($"Mandatory Field: {nameof(Deal.IsActive)}");
        }
    }
}
