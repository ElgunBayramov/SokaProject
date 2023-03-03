using FluentValidation;
using Soka.Domain.Business.BrandModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Validators.BrandValidators
{
    public class BrandCreateCommandValidator : AbstractValidator<BrandCreateCommand>
    {
        public BrandCreateCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Marka adı qeyd edilməyib");
        }
    }
}
