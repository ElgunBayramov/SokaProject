using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.LeagueModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LeaguesController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<LeagueCreateCommand> leagueCreateCommandValidator;
        private readonly IValidator<LeagueEditCommand> leagueEditCommandValidator;

        public LeaguesController(IMediator mediator,
            IValidator<LeagueCreateCommand> leagueCreateCommandValidator,
            IValidator<LeagueEditCommand> leagueEditCommandValidator)
        {
            this.mediator = mediator;
            this.leagueCreateCommandValidator = leagueCreateCommandValidator;
            this.leagueEditCommandValidator = leagueEditCommandValidator;
        }

        public async Task<IActionResult> Index(LeaguesAllQuery query)
        {
            var data = await mediator.Send(query);
            return View(data);
        }

        public async Task<IActionResult> Details(LeagueSingleQuery query)
        {
            var data = await mediator.Send(query);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeagueCreateCommand command)
        {
            //validate - with fluent validation

            var result = leagueCreateCommandValidator.Validate(command);

            if (result.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View();
        }
        public async Task<IActionResult> Edit(LeagueSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LeagueEditCommand command)
        {
            //validate - with fluent validation

            var result = leagueEditCommandValidator.Validate(command);

            if (result.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Remove(LeagueRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var data = await mediator.Send(new LeaguesAllQuery());
            return PartialView("_ListBody", data);
        }
    }
}
       