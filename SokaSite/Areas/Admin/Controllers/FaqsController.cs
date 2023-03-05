using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.FaqModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FaqsController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<FaqCreateCommand> faqCreateCommandValidator;
        private readonly IValidator<FaqEditCommand> faqEditCommandValidator;

        public FaqsController(IMediator mediator,
            IValidator<FaqCreateCommand> faqCreateCommandValidator,
            IValidator<FaqEditCommand> faqEditCommandValidator)
        {
            this.mediator = mediator;
            this.faqCreateCommandValidator = faqCreateCommandValidator;
            this.faqEditCommandValidator = faqEditCommandValidator;
        }

        public async Task<IActionResult> Index(FaqsAllQuery query)
        {
            var data = await mediator.Send(query);
            return View(data);
        }

        public async Task<IActionResult> Details(FaqSingleQuery query)
        {
            var data = await mediator.Send(query);
            if(data == null)
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
        public async Task<IActionResult> Create(FaqCreateCommand command)
        {
            //validate - with fluent validation

            var result = faqCreateCommandValidator.Validate(command);

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

        public async Task<IActionResult> Edit(FaqSingleQuery query)
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
        public async Task<IActionResult> Edit(FaqEditCommand command)
        {
            //validate - with fluent validation

            var result = faqEditCommandValidator.Validate(command);

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
        public async Task<IActionResult> Remove(FaqRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var data = await mediator.Send(new FaqsAllQuery());
            return PartialView("_ListBody", data);
        }
    }
}
