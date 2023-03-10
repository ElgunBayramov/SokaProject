using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.ProductSizeModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductSizesController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<ProductSizeCreateCommand> productsizeCreateCommandValidator;
        private readonly IValidator<ProductSizeEditCommand> productsizeEditCommandValidator;

        public ProductSizesController(IMediator mediator,
            IValidator<ProductSizeCreateCommand> productsizeCreateCommandValidator,
              IValidator<ProductSizeEditCommand> productsizeEditCommandValidator)
        {
            this.mediator = mediator;
            this.productsizeCreateCommandValidator = productsizeCreateCommandValidator;
            this.productsizeEditCommandValidator = productsizeEditCommandValidator;
        }

        public async Task<IActionResult> Index(ProductSizesAllQuery query)
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
        public async Task<IActionResult> Create(ProductSizeCreateCommand command)
        {
            //validate - with fluent validation

            var result = productsizeCreateCommandValidator.Validate(command);

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
        public async Task<IActionResult> Edit(ProductSizeSingleQuery query)
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
        public async Task<IActionResult> Edit(ProductSizeEditCommand command)
        {
            //validate - with fluent validation

            var result = productsizeEditCommandValidator.Validate(command);

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
        public async Task<IActionResult> Details(ProductSizeSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(ProductSizeRemoveCommand command)
        {
            var response = await mediator.Send(command);
            if (response.Error)
            {
                return Json(Response);
            }
            var data = await mediator.Send(new ProductSizesAllQuery());
            return PartialView("_ListBody", data);
        }
    }
}
