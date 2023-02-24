using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soka.Domain.Business.LeagueModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LeaguesController : Controller
    {
        private readonly IMediator mediator;

        public LeaguesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(LeaguesAllQuery query)
        {
            var data = await mediator.Send(query);
            return View(data);
        }

        public async Task<IActionResult> Details(LeagueSingleQuery query)
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
        public async Task<IActionResult> Create(LeagueCreateCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(LeagueSingleQuery query)
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
        public async Task<IActionResult> Edit(int id, LeagueEditCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }
            var response = await mediator.Send(command);
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Remove(LeagueRemoveCommand command)
        {
            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var data = await mediator.Send(new LeaguesAllQuery());
            return PartialView("_ListBody", data);
        }
    }
}
       