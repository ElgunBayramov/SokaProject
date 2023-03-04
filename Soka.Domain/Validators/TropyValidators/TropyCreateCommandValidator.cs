using FluentValidation;
using Soka.Domain.Business.TropyModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Validators.TropyValidators
{
    public class TropyCreateCommandValidator : AbstractValidator<TropyCreateCommand>
    {
        public TropyCreateCommandValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Kubok adı qeyd edilməyib");

            RuleFor(m => m.Body)
                .NotEmpty()
                .WithMessage("Xana boş buraxıla bilməz");

            RuleFor(c => c.Image)
               .NotNull()
               .WithMessage("Şəkil seçilməyib");
        }
    }
}
