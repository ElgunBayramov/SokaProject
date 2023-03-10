using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.ProductTypeModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<ProductTypeCreateCommand> productTypeCreateCommandValidator;
        private readonly IValidator<ProductTypeEditCommand> productTypeEditCommandValidator;

        public ProductTypesController(IMediator mediator,
            IValidator<ProductTypeCreateCommand> productTypeCreateCommandValidator,
              IValidator<ProductTypeEditCommand> productTypeEditCommandValidator)
        {
            this.mediator = mediator;
            this.productTypeCreateCommandValidator = productTypeCreateCommandValidator;
            this.productTypeEditCommandValidator = productTypeEditCommandValidator;
        }

        public async Task<IActionResult> Index(ProductTypesAllQuery query)
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
        public async Task<IActionResult> Create(ProductTypeCreateCommand command)
        {
            //validate - with fluent validation

            var result = productTypeCreateCommandValidator.Validate(command);

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
        public async Task<IActionResult> Edit(ProductTypeSingleQuery query)
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
        public async Task<IActionResult> Edit(ProductTypeEditCommand command)
        {
            //validate - with fluent validation

            var result = productTypeEditCommandValidator.Validate(command);

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
        public async Task<IActionResult> Details(ProductTypeSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(ProductTypeRemoveCommand command)
        {
            var response = await mediator.Send(command);
            if (response.Error)
            {
                return Json(Response);
            }
            var data = await mediator.Send(new ProductTypesAllQuery());
            return PartialView("_ListBody", data);
        }
    }
}
