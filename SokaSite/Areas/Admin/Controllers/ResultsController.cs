using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Business.ResultModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResultsController : Controller
    {
        private readonly IMediator mediator;

        public ResultsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(ResultsAllQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }

        public async Task<IActionResult> Details(ResultSingleQuery query)
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
        public async Task<IActionResult> Create(ResultCreateCommand command)
        {
            if (command.Image == null)
            {
                ModelState.AddModelError("Image", "Şəkil seçilməyib");
            }
            if (command.Image2 == null)
            {
                ModelState.AddModelError("Image2", "Şəkil seçilməyib");
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
        public async Task<IActionResult> Edit(ResultSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            var command = new ResultEditCommand();
            command.Title = response.Title;
            command.Body = response.Body;
            command.ClubName = response.ClubName;
            command.RivalClubName = response.RivalClubName;
            command.ImagePath = response.ImagePath;
            command.RivalImagePath = response.RivalImagePath;
            return View(command);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ResultEditCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return View(command);
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> Remove(ResultRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var data = await mediator.Send(new ResultsAllQuery());
            return PartialView("_ListBody", data);
        }
    }
}
