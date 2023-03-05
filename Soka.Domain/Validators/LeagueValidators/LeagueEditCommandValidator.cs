using FluentValidation;
using Soka.Domain.Business.LeagueModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Validators.LeagueValidators
{
    public class LeagueEditCommandValidator : AbstractValidator<LeagueEditCommand>
    {
        public LeagueEditCommandValidator()
        {
            RuleFor(m => m.Id)
               .GreaterThanOrEqualTo(1)
               .WithMessage("Id minimum 1 ola bilər");

            RuleFor(m => m.Body)
                .NotEmpty()
                .WithMessage("Komando adları qeyd edilməyib");

            RuleFor(m => m.Venue)
                .NotEmpty()
                .WithMessage("Məkan adı qeyd edilməyib");

        }
    }
}
