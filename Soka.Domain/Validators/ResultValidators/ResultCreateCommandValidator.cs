using FluentValidation;
using Soka.Domain.Business.ResultModule;

namespace Soka.Domain.Validators.ResultValidators
{
    public class ResultCreateCommandValidator : AbstractValidator<ResultCreateCommand>
    {
        public ResultCreateCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .WithMessage("Liga adı boş buraxıla bilməz");

            RuleFor(c => c.Body)
                .NotEmpty()
                .WithMessage("Hesab boş buraxıla bilməz");

            RuleFor(c => c.ClubName)
                .NotNull()
                .WithMessage("Komando adı boş buraxıla bilməz");

            RuleFor(c => c.RivalClubName)
                .NotNull()
                .WithMessage("Rəqib komando adı boş buraxıla bilməz");

            RuleFor(c => c.Image)
                .NotNull()
                .WithMessage("Şəkil seçilməyib");

            RuleFor(c => c.Image2)
                .NotNull()
                .WithMessage("Şəkil seçilməyib");
        }
    }
}
