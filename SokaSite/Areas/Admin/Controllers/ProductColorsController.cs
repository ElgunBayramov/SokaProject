using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ProductColorsController(IMediator mediator)
        {
            this.mediator = mediator;
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
            var response = await mediator.Send(command);
            if (response == null)
            {
                return View(command);
            }
            return RedirectToAction(nameof(Index));
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
            var response = await mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
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
