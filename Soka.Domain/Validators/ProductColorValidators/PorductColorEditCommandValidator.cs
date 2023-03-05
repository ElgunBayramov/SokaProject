using FluentValidation;
using Soka.Domain.Business.ProductColorModule;

namespace Soka.Domain.Validators.ProductColorValidators
{
    public class ProductColorEditCommandValidator : AbstractValidator<ProductColorEditCommand>
    {
        public ProductColorEditCommandValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Id minimum 1 ola bilər");

            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Rəng qeyd edilməyib");
        }
    }
}
