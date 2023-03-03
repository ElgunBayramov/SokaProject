using FluentValidation;
using Soka.Domain.Business.BrandModule;

namespace Soka.Domain.Validators.BrandValidators
{
    public class BrandEditCommandValidator : AbstractValidator<BrandEditCommand>
    {
        public BrandEditCommandValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Id minimum 1 ola bilər");

            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Marka adı qeyd edilməyib");
        }
    }
}
