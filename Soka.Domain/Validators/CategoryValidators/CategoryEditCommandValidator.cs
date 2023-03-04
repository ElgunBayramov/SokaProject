using FluentValidation;
using Soka.Domain.Business.CategoryModule;

namespace Soka.Domain.Validators.CategoryValidators
{
    public class CategoryEditCommandValidator : AbstractValidator<CategoryEditCommand>
    {
        public CategoryEditCommandValidator()
        {
            RuleFor(m => m.Id)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Id minimum 1 ola bilər");

            RuleFor(m => m.Name)
                .NotEmpty()
                .WithMessage("Kategoriya adı qeyd edilməyib");
        }
    }
}
