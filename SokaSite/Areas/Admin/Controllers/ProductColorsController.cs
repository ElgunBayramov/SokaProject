using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Business.ProductColorModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductColorsController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<ProductColorCreateCommand> productcolorCreateCommandValidator;
        private readonly IValidator<ProductColorEditCommand> productcolorEditCommandValidator;

        public ProductColorsController(IMediator mediator,
             IValidator<ProductColorCreateCommand> productcolorCreateCommandValidator,
              IValidator<ProductColorEditCommand> productcolorEditCommandValidator)
        {
            this.mediator = mediator;
            this.productcolorCreateCommandValidator = productcolorCreateCommandValidator;
            this.productcolorEditCommandValidator = productcolorEditCommandValidator;
        }
        [Authorize(Policy = "admin.productcolors.index")]
        public async Task<IActionResult> Index(ProductColorsAllQuery query)
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
        public async Task<IActionResult> Create(ProductColorCreateCommand command)
        {
            //validate - with fluent validation

            var result = productcolorCreateCommandValidator.Validate(command);

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
        public async Task<IActionResult> Edit(ProductColorSingleQuery query)
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
        public async Task<IActionResult> Edit(ProductColorEditCommand command)
        {
            //validate - with fluent validation

            var result = productcolorEditCommandValidator.Validate(command);

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
        public async Task<IActionResult> Details(ProductColorSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }
        [HttpPost]
    
        public async Task<IActionResult> Remove(ProductColorRemoveCommand command)
        {
            var response = await mediator.Send(command);
            if (response.Error)
            {
                return Json(Response);
            }
            var data = await mediator.Send(new ProductColorsAllQuery());
            return PartialView("_ListBody", data);
        }
    }
}
