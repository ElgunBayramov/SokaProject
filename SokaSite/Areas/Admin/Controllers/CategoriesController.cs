using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Application.AppCode.Extensions;
using Soka.Domain.Business.CategoryModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<CategoryCreateCommand> categoryCreateCommandValidator;
        private readonly IValidator<CategoryEditCommand> categoryEditCommandValidator;

        public CategoriesController(IMediator mediator,
            IValidator<CategoryCreateCommand> categoryCreateCommandValidator,
            IValidator<CategoryEditCommand> categoryEditCommandValidator)
        {
            this.mediator = mediator;
            this.categoryCreateCommandValidator = categoryCreateCommandValidator;
            this.categoryEditCommandValidator = categoryEditCommandValidator;
        }

        public async Task<IActionResult> Index(CategoryPagedQuery query)
        {
            var response = await mediator.Send(query);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListBody", response);
            }

            return View(response);
        }

        public async Task<IActionResult> Details(CategorySingleQuery query)
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
        public async Task<IActionResult> Create(CategoryCreateCommand command)
        {
            //validate - with fluent validation

            var result = categoryCreateCommandValidator.Validate(command);

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

        public async Task<IActionResult> Edit(CategorySingleQuery query)
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
        public async Task<IActionResult> Edit(CategoryEditCommand command)
        {
            //validate - with fluent validation

            var result = categoryEditCommandValidator.Validate(command);

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
        public async Task<IActionResult> Remove(CategoryRemoveCommand command)
        {
            var response = await mediator.Send(command);
            if (response.Error)
            {
                return Json(Response);
            }
            var newQuery = new CategoryPagedQuery
            {
                PageIndex = command.PageIndex,
                PageSize = command.PageSize
            };
            var data = await mediator.Send(newQuery);
            return PartialView("_ListBody", data);
        }

    }
}
