using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.TropyModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrophiesController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<TropyCreateCommand> tropyCreateCommandValidator;
        private readonly IValidator<TropyEditCommand> tropyEditCommandValidator;

        public TrophiesController(IMediator mediator,
             IValidator<TropyCreateCommand> tropyCreateCommandValidator,
            IValidator<TropyEditCommand> tropyEditCommandValidator)
        {
            this.mediator = mediator;
            this.tropyCreateCommandValidator = tropyCreateCommandValidator;
            this.tropyEditCommandValidator = tropyEditCommandValidator;
        }

        public async Task<IActionResult> Index(TrophiesAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        public async Task<IActionResult> Details(TropySingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TropyCreateCommand command)
        {
            //validate - with fluent validation

            var result = tropyCreateCommandValidator.Validate(command);

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
        public async Task<IActionResult> Edit(TropySingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            var command = new TropyEditCommand();
            command.Title = response.Title;
            command.Body = response.Body;
            command.ImagePath = response.ImagePath;
            return View(command);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TropyEditCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return View(command);
            }

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Remove(TropyRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var data = await mediator.Send(new TrophiesAllQuery());
            return PartialView("_ListBody", data);
        }

    }
}
