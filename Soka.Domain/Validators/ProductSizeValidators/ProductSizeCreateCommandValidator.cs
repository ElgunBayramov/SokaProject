using FluentValidation;
using Soka.Domain.Business.ProductSizeModule;

namespace Soka.Domain.Validators.ProductSizeValidators
{
    public class ProductSizeCreateCommandValidator : AbstractValidator<ProductSizeCreateCommand>
    {
        public ProductSizeCreateCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Ölçü qeyd edilməyib");
        }
    }
}
