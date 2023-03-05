using FluentValidation;
using Soka.Domain.Business.ProductColorModule;

namespace Soka.Domain.Validators.ProductColorValidators
{
    public class ProductColorCreateCommandValidator : AbstractValidator<ProductColorCreateCommand>
    {
        public ProductColorCreateCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Rəng qeyd edilməyib");
        }
    }
}
