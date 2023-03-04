using FluentValidation;
using Soka.Domain.Business.TropyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Validators.TropyValidators
{
    public class TropyEditCommandValidator : AbstractValidator<TropyEditCommand>
    {
        public TropyEditCommandValidator()
        {
            RuleFor(m => m.Id)
             .GreaterThanOrEqualTo(1)
             .WithMessage("Id minimum 1 ola bilər");

            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Sual qeyd edilməyib");

            RuleFor(m => m.Body)
                .NotEmpty()
                .WithMessage("Cavab qeyd edilməyib");

            RuleFor(c => c.Image)
               .NotNull()
               .WithMessage("Şəkil seçilməyib");
        }
    }
}
