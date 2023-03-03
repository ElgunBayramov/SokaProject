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
using Soka.Domain.Business.BrandModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;

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
        [Authorize(Policy = "admin.brands.index")]
        public async Task<IActionResult> Index(BrandsAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        [Authorize(Policy = "admin.brands.create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.brands.create")]
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
        [Authorize(Policy = "admin.brands.edit")]
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
        [Authorize(Policy = "admin.brands.edit")]
        public async Task<IActionResult> Edit(BrandEditCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Policy = "admin.brands.details")]
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
        [Authorize(Policy = "admin.brands.remove")]
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
