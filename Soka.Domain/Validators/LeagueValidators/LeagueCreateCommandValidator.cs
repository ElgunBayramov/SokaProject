using FluentValidation;
using Soka.Domain.Business.LeagueModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soka.Domain.Validators.LeagueValidators
{
    public class LeagueCreateCommandValidator : AbstractValidator<LeagueCreateCommand>
    {
        public LeagueCreateCommandValidator()
        {
            RuleFor(m => m.Body)
                .NotEmpty()
                .WithMessage("Komando adları qeyd edilməyib");

            RuleFor(m => m.Venue)
                .NotEmpty()
                .WithMessage("Məkan adı qeyd edilməyib");

        }
    }
}
