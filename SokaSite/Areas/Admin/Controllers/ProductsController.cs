using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Soka.Domain.Business.CategoryModule;
using Soka.Domain.Business.BrandModule;
using Soka.Domain.Business.ProductModule;
using System.Threading.Tasks;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<ProductCreateCommand> productCreateCommandValidator;
        private readonly IValidator<ProductEditCommand> productEditCommandValidator;

        public ProductsController(IMediator mediator,
            IValidator<ProductCreateCommand> productCreateCommandValidator,
            IValidator<ProductEditCommand> productEditCommandValidator)
        {
            this.mediator = mediator;
            this.productCreateCommandValidator = productCreateCommandValidator;
            this.productEditCommandValidator = productEditCommandValidator;
        }
        public async Task<IActionResult> Index(ProductsAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        public async Task<IActionResult> Create()
        {
            var brands = await mediator.Send(new BrandsAllQuery());
            ViewBag.BrandId = new SelectList(brands, "Id", "Name");
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            //validate - with fluent validation

            var result = productCreateCommandValidator.Validate(command);

            if (result.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            var brands = await mediator.Send(new BrandsAllQuery());
            ViewBag.BrandId = new SelectList(brands, "Id", "Name");
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return View();
        }
        public async Task<IActionResult> Edit(ProductSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            var brands = await mediator.Send(new BrandsAllQuery());
            ViewBag.BrandId = new SelectList(brands, "Id", "Name");
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            var command = new ProductEditCommand();
            command.Name = response.Name;
            command.ShortDescription = response.ShortDescription;
            command.Description = response.Description;
            command.BrandId = response.BrandId;
            command.CategoryId = response.CategoryId;
            command.ImagePath = response.ImagePath;
            return View(command);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                var brands = await mediator.Send(new BrandsAllQuery());
                ViewBag.BrandId = new SelectList(brands, "Id", "Name");
                var categories = await mediator.Send(new CategoryAllQuery());
                ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
                return View(command);
            }

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(ProductSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Remove(ProductRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var data = await mediator.Send(new ProductsAllQuery());
            return PartialView("_ListBody", data);
        }


    }
}
