using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.BrandModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<BrandCreateCommand> brandCreateCommandValidator;
        private readonly IValidator<BrandEditCommand> brandEditCommandValidator;

        public BrandsController(IMediator mediator,
            IValidator<BrandCreateCommand> brandCreateCommandValidator,
            IValidator<BrandEditCommand> brandEditCommandValidator)
        {
            this.brandCreateCommandValidator = brandCreateCommandValidator;
            this.brandEditCommandValidator = brandEditCommandValidator;
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(BrandsAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandCreateCommand command)
        {
            //validate - with fluent validation

            var result = brandCreateCommandValidator.Validate(command);

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
        public async Task<IActionResult> Edit(BrandSingleQuery query)
        {
            var response = await mediator.Send(query);
            if(response == null)
            {
                return NotFound();
            }
            return View(response);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandEditCommand command)
        {
            var result = brandEditCommandValidator.Validate(command);

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
        public async Task<IActionResult> Details(BrandSingleQuery query)
        {
            var response = await mediator.Send(query);
            if(response == null)
            {
                return NotFound();
            }
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(BrandRemoveCommand command)
        {
            var response = await mediator.Send(command);
            if(response.Error)
            {
                return Json(Response);
            }
            var data = await mediator.Send(new BrandsAllQuery());
            return PartialView("_ListBody", data);
        }
    }
}
