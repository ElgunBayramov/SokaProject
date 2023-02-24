using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Soka.Domain.AppCode.Extensions;
using Soka.Domain.Business.TropyModule;
using Soka.Domain.Business.TagModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrophiesController : Controller
    {
        private readonly IMediator mediator;

        public TrophiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(TrophiesAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        public async Task<IActionResult> Details(TropySingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TropyCreateCommand command)
        {
            if (command.Image == null)
            {
                ModelState.AddModelError("Image", "Şəkil seçilməyib");
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
        public async Task<IActionResult> Edit(TropySingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            var command = new TropyEditCommand();
            command.Title = response.Title;
            command.Body = response.Body;
            command.ImagePath = response.ImagePath;
            return View(command);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TropyEditCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return View(command);
            }

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Remove(TropyRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var data = await mediator.Send(new TrophiesAllQuery());
            return PartialView("_ListBody", data);
        }

    }
}
