using FluentValidation;
using Soka.Domain.Business.ProductSizeModule;

namespace Soka.Domain.Validators.ProductSizeValidators
{
    public class ProductSizeEditCommandValidator : AbstractValidator<ProductSizeEditCommand>
    {
        public ProductSizeEditCommandValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Id minimum 1 ola bilər");

            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Ölçü qeyd edilməyib");
        }
    }
}
