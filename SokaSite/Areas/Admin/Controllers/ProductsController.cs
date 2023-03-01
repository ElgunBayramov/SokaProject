using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Soka.Domain.Business.BlogPostModule;
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

        public ProductsController(IMediator mediator,
            IValidator<ProductCreateCommand> productCreateCommandValidator)
        {
            this.mediator = mediator;
            this.productCreateCommandValidator = productCreateCommandValidator;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "chief")]
        public async Task<IActionResult> Create()
        {
            var brands = await mediator.Send(new BrandsAllQuery());
            ViewBag.BrandId = new SelectList(brands, "Id", "Name");
            var categories = await mediator.Send(new CategoryAllQuery());
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }
        [HttpPost]
        [Authorize(Roles="chief")]
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
    }
}
