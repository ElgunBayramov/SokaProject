using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Soka.Application.AppCode.Extensions;
using Soka.Domain.Business.ContactModule;
using Soka.Domain.Business.FaqModule;
using Soka.Domain.Models.DataContexts;
using Soka.Domain.Models.Entities;

namespace Soka.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IMediator mediator;

        public ContactController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(ContactPagedQuery query)
        {
            var response = await mediator.Send(query);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ListBody", response);
            }

            return View(response);
        }
        public async Task<IActionResult> Edit(ContactSingleQuery query)
        {
            var response = await mediator.Send(query);
            if (response == null)
            {
                return NotFound();
            }
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ContactAnswerCommand command)
        {
            var response = await mediator.Send(command);
            if (response == null)
            {
                return View(command);
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(ContactSingleQuery query)
        {
            var response = await mediator.Send(query);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Remove(ContactRemoveCommand command)
        {

            var response = await mediator.Send(command);


            if (response.Error)
            {
                return Json(response);
            }

            var data = await mediator.Send(new ContactPagedQuery());

            return PartialView("_ListBody", data);
        }
    }
}
