using FluentValidation;
using Soka.Domain.Business.FaqModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Validators.FaqValidators
{
    public class FaqEditCommandValidator : AbstractValidator<FaqEditCommand>
    {
        public FaqEditCommandValidator()
        {
            RuleFor(m => m.Id)
               .GreaterThanOrEqualTo(1)
               .WithMessage("Id minimum 1 ola bilər");

            RuleFor(m => m.Answer)
                .NotEmpty()
                .WithMessage("Sual qeyd edilməyib");

            RuleFor(m => m.Question)
                .NotEmpty()
                .WithMessage("Cavab qeyd edilməyib");
        }
    }
}
