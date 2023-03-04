using FluentValidation;
using Soka.Domain.Business.CategoryModule;

namespace Soka.Domain.Validators.CategoryValidators
{
    public class CategoryCreateCommandValidator : AbstractValidator<CategoryCreateCommand>
    {
        public CategoryCreateCommandValidator()
        {
            RuleFor(m => m.Name)
               .NotEmpty()
               .WithMessage("Kategoriya adı qeyd edilməyib");
        }
    }
}
