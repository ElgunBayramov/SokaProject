using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Business.ProductSizeModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductSizesController : Controller
    {
        private readonly IMediator mediator;

        public ProductSizesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(ProductSizesAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        [Authorize(Policy = "admin.productsizes.create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "admin.productsizes.create")]
        public async Task<IActionResult> Create(ProductSizeCreateCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return View(command);
            }
            return RedirectToAction(nameof(Index));
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
            var response = await mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
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
