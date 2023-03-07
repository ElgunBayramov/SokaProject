using FluentValidation;
using Soka.Domain.Business.ProductTypeModule;

namespace Soka.Domain.Validators.ProductTypeValidators
{
    public class ProductTypeEditCommandValidator : AbstractValidator<ProductTypeEditCommand>
    {
        public ProductTypeEditCommandValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Id minimum 1 ola bilər");

            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Bu xana boş buraxıla bilməz");
        }
    }
}
