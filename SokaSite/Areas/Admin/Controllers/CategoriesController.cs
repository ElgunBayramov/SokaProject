using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Business.CategoryModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IMediator mediator;
        private readonly IValidator<CategoryCreateCommand> categoryCreateCommandValidator;

        public CategoriesController(IMediator mediator,
            IValidator<CategoryCreateCommand> categoryCreateCommandValidator)
        {
            this.mediator = mediator;
            this.categoryCreateCommandValidator = categoryCreateCommandValidator;
        }

        public async Task<IActionResult> Index(CategoryAllQuery query)
        {
            var data = await mediator.Send(query);
            return View(data);
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
            var response = await mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Remove(CategoryRemoveCommand command)
        {
            var response = await mediator.Send(command);
            if (response.Error)
            {
                return Json(Response);
            }
            var data = await mediator.Send(new CategoryAllQuery());
            return PartialView("_ListBody", data);
        }

    }
}
