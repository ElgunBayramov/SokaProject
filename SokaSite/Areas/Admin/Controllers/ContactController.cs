using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soka.Domain.Business.ContactModule;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Index(ContactsAllQuery query)
        {
            var response = await mediator.Send(query);
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

            var data = await mediator.Send(new ContactsAllQuery());

            return PartialView("_ListBody", data);
        }
    }
}
