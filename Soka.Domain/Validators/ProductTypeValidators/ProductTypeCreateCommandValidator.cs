using FluentValidation;
using Soka.Domain.Business.ProductTypeModule;

namespace Soka.Domain.Validators.ProductTypeValidators
{
    public class ProductTypeCreateCommandValidator : AbstractValidator<ProductTypeCreateCommand>
    {
        public ProductTypeCreateCommandValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Bu xana boş buraxıla bilməz");
        }
    }
}
