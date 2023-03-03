using FluentValidation;
using Soka.Domain.Business.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Validators.ProductValidators
{
    public class ProductEditCommandValidator : AbstractValidator<ProductEditCommand>
    {
        public ProductEditCommandValidator()
        {
            RuleFor(m => m.Id)
              .GreaterThanOrEqualTo(1)
              .WithMessage("Id minimum 1 ola bilər");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Ad boş buraxıla bilməz");

            RuleFor(c => c.ShortDescription)
                .NotEmpty()
                .WithMessage("Xana boş buraxıla bilməz")
                .MaximumLength(250)
                .WithMessage("250 simvoldan çox ola bilməz");

            RuleFor(c => c.BrandId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Marka seçilməyib")
                .NotNull()
                .WithMessage("Marka seçilməyib");

            RuleFor(c => c.CategoryId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Kateqoriya seçilməyib")
                .NotNull()
                .WithMessage("Kateqoriya seçilməyib");

            RuleFor(c => c.Image)
                .NotNull()
                .WithMessage("Şəkil seçilməyib");
        }
    }
}
